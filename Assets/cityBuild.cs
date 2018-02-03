using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BuilderScript))]
public class cityBuild : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BuilderScript myScript = (BuilderScript)target;
        if (GUILayout.Button("Generate building node"))
        {
            myScript.MakeNode();
        }
    }
}
