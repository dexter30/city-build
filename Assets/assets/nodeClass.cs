using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//
[ExecuteInEditMode]
public class nodeClass : MonoBehaviour {

    //Planned Build: The prefab being used as the path or road for the player
    //Decor left and right are the placeholder for objects on the side of the road
    //TODO: randomise the decorations to random range of prefabs instead of a singular object
    private GameObject plannedBuild;
    private GameObject decorLeft;
    private GameObject decorRight;
    private Vector3 unitT;
    
    private GameObject nextNode;
    private int numberBlocks;

    //Road: List of the objects in this nodes instance. 
    public List<GameObject> road = new List<GameObject>();
    public Object[] matters;
    [SerializeField]
    private float distanceBetNodes;
    
    //Load all the materials at the beginning
	void Start () {
         string mat = "PolygonCity/Materials";
        matters = Resources.LoadAll(mat, typeof(Material));
    }
	

    public void AssignNode(GameObject next)
    {
        nextNode = next;
    }

    //Function so the script class can assign the prefabs to the nodes script.
    //Required for execution in edit mode.
    public void AssignStructure(GameObject _buildChoice, GameObject _decorChoiceL, GameObject _decorChoiceR)
    {
        plannedBuild = _buildChoice;
        decorLeft = _decorChoiceL;
        decorRight = _decorChoiceR;
    }

    //Function for executing the code for placement of prefabs in scene.
    public void placeBuildings()
    {
        //Get distance between the nodes
        if (nextNode)
        {
            distanceBetNodes = Vector3.Distance(transform.position, nextNode.transform.position);
            unitT = Vector3.Normalize(transform.position - nextNode.transform.position);
        }

        //Clears out previous objects if node has been run before.
        for (int i = 0; i < road.Count; i++)
        {
            GameObject.DestroyImmediate(road[i]);
            
        }
        road.Clear();

        //Following code is for placement and instantiation of the prefabs in the scene.


        if (nextNode )
        {
        
         //numberblocks allows us to note how many prefabs we can fit between the nodes. 
         numberBlocks = Mathf.RoundToInt(distanceBetNodes / plannedBuild.GetComponent<BoxCollider>().size.x);

        //dir is the direction the prefab is facing.
        Vector3 plannedPosition;
        Vector3 dir;
        dir = Vector3.Cross(unitT, Vector3.up);
        plannedPosition = transform.position;
        for (int i = 0; i < numberBlocks + 1; i++)
        {
        

        road.Add(Instantiate(plannedBuild, plannedPosition, Quaternion.LookRotation(dir, Vector3.up)) as GameObject);
        plannedPosition += ((nextNode.transform.position - transform.position) / (distanceBetNodes / plannedBuild.GetComponent<BoxCollider>().size.x));
        
        }

        //Instantiating the decoration for the sides of the path is just repeated using the same initaial vector
        //but with an offset
        if (decorLeft != null)
        {
            numberBlocks = Mathf.RoundToInt(distanceBetNodes / decorLeft.GetComponent<BoxCollider>().size.x);
            plannedPosition = transform.position;
            
            for (int i = 0; i < numberBlocks + 1; i++)
            {

                    Vector3 newPos = plannedPosition - (Vector3.Cross(unitT, Vector3.up)) * decorLeft.GetComponent<BoxCollider>().size.z;
                    //newPos.z -= decorLeft.GetComponent<BoxCollider>().size.z;
                    road.Add(Instantiate(decorLeft, newPos, Quaternion.LookRotation(dir, Vector3.up)) as GameObject);


                plannedPosition += ((nextNode.transform.position - transform.position) / (distanceBetNodes / decorLeft.GetComponent<BoxCollider>().size.x));

            }
        }
        if (decorRight != null)
        {
            numberBlocks = Mathf.RoundToInt(distanceBetNodes / decorRight.GetComponent<BoxCollider>().size.x);
            plannedPosition = transform.position;
            for (int i = 0; i < numberBlocks + 1; i++)
            {
                    //Vector3 newPos = plannedPosition + (Vector3.Cross(unitT, Vector3.up)) * 6.0f;
                    Vector3 newPos = plannedPosition + Vector3.Cross(unitT, Vector3.up) * decorRight.GetComponent<BoxCollider>().size.z;
                    //newPos.z += decorRight.GetComponent<BoxCollider>().size.z;
                  
                    GameObject building = Instantiate(decorRight, newPos, Quaternion.LookRotation(-dir, Vector3.up)) as GameObject;
                
                //Material code being tested out here. 

                int bing = Mathf.RoundToInt(Random.Range(0, matters.Length));
                building.GetComponent<Renderer>().material = (Material)matters[bing];
                road.Add(building);
                plannedPosition += ((nextNode.transform.position - transform.position) / (distanceBetNodes / decorRight.GetComponent<BoxCollider>().size.x));
            }

        }

                nextNode.GetComponent<nodeClass>().placeBuildings();
        }
    }

}
