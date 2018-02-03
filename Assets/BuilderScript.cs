using UnityEngine;
using System.Collections;

public class BuilderScript : MonoBehaviour {

    public GameObject refLastNode;
    private GameObject nodeToAssign;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeNode()
    {
        if (refLastNode)
            nodeToAssign = refLastNode;
        refLastNode  = Instantiate(Resources.Load("nodes", typeof(GameObject))) as GameObject;
        refLastNode.GetComponent<nodeClass>().AssignNode(nodeToAssign);
    }
}
