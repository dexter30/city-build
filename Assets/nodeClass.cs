using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class nodeClass : MonoBehaviour {

    private GameObject nextNode;
    List<Buildings> road = new List<Buildings>();

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AssignNode(GameObject next)
    {
        nextNode = next;
    }
    

}
