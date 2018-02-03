using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BuilderScript))]
public class cityBuild : Editor {

    

	//Script for connecting the editor to the nodes
    //For construction.

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BuilderScript myScript = (BuilderScript)target;
        if (GUILayout.Button("Generate building node"))
        {
            myScript.MakeNode();
        }
        if (GUILayout.Button("Build"))
        {
            myScript.MakeBuild(myScript.plannedBuild, myScript.decorationL, myScript.decorationR);
        }
    }
}
