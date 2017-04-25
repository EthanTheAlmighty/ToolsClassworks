using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawLine))]
public class DrawLineEditor : Editor {

    void OnEnable()
    {
        SceneView.onSceneGUIDelegate -= this.MyGUI;

        SceneView.onSceneGUIDelegate += this.MyGUI;
    }

    void OnDestroy()
    {
        //SceneView.onSceneGUIDelegate -= this.MyGUI;
    }
    void OnSceneGUI()
    {
    }

    void MyGUI(SceneView sv)
    {
        DrawLine dl = target as DrawLine;

        if (dl == null || dl.GameObjects == null)
            return;

        Vector3 center = dl.transform.position;

        for (int i = 0; i < dl.GameObjects.Length; i++)
        {
            if(dl.GameObjects[i] != null)
            {
                Handles.DrawLine(center, dl.GameObjects[i].transform.position);
            }
        }

        Handles.BeginGUI();
        GUILayout.BeginArea(new Rect(10,10,100,100));
        if(GUILayout.Button("Reset"))
        {
            Debug.Log("I'm active");
            dl.transform.position = Vector3.zero;
        }
        GUILayout.EndArea();
        Handles.EndGUI();


        Handles.color = CustomColors.puce;
        Handles.DrawWireArc(dl.transform.position, dl.transform.up, -dl.transform.right, dl.shieldArc, dl.shieldArea);
        dl.shieldArea = Handles.ScaleValueHandle(dl.shieldArea, dl.transform.position + dl.transform.forward * dl.shieldArea, dl.transform.rotation, 2, Handles.ConeCap, 1);

    }

}
