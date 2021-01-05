using UnityEngine;
using System.Collections;
using UnityEditor;
 
public class IDSee : Editor {
 
	[DrawGizmo( GizmoType.NotInSelectionHierarchy|GizmoType.Selected)]
	static void DrawGameObjectName(ObjID transform, GizmoType gizmoType)
	{   
        Vector3 position = transform.transform.position;
        string name = transform.ID.ToString();
        if((gizmoType&GizmoType.Selected)!=0)
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.red;
            style.fontSize = 20;
		    Handles.Label(position,name,style);
        }else
        {
     
		    Handles.Label(position,name);
        }
	}

}

// [CustomEditor(typeof(ObjID))]
// class LabelHandle : Editor
// {
//     void OnSceneGUI()
//     {
//         ObjID handleExample = (ObjID)target;
//         if (handleExample == null)
//         {
//             Debug.Log(handleExample.ID);
//             return;
//         }

//         Handles.color = Color.blue;
//         Handles.Label(handleExample.transform.position + Vector3.up * 2,
//             handleExample.transform.position.ToString() + "\nShieldArea: " 
//             );

//         Handles.BeginGUI();
//         if (GUILayout.Button("Reset Area", GUILayout.Width(100)))
//         {
//         }
//         Handles.EndGUI();


  
//     }
// }