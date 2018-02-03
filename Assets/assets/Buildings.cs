using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Buildings : MonoBehaviour {
    Collider ObjectSpace;
    
    // Use this for initialization
    void Start() {
       
        Vector3 fwd = transform.TransformDirection(Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        { 
            if(hit.collider.tag == "surface")
             transform.position = new Vector3(hit.point.x, (hit.point.y), hit.point.z);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.down) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    
}
