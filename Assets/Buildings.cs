using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class Buildings : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Vector3 fwd = transform.TransformDirection(Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
            transform.position = hit.point + (transform.localScale/2.0f);
            
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.down) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    
}
