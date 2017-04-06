using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow {

    List<Rect> myRectList = new List<Rect>();

    [MenuItem("Window/Node Editor")]
	public static void GetWindow()
    {
        EditorWindow.GetWindow<NodeEditor>();
    }

    void OnGUI()
    {
        if(myRectList.Count>1)
        {
            DrawNodeConnection(myRectList[0], myRectList[1]);
        }
        if(GUILayout.Button("Add node"))
        {
            myRectList.Add(new Rect(10, 10, 100, 100));
        }
        BeginWindows();
        for(int i = 0; i < myRectList.Count; i++)
        {
            myRectList[i] = GUI.Window(i, myRectList[i], DrawNodeWindow, "Window" + i);
        }
        EndWindows();
    }

    void DrawNodeWindow(int id)
    {
        Color temp = GUI.backgroundColor;
        GUI.backgroundColor = Color.red;
        if(GUI.Button(new Rect(myRectList[id].width - 18, -1, 18, 18), "X"))
        {
            myRectList.RemoveAt(id);
        }
        GUI.backgroundColor = temp;

        //once this is called it captures all user input, must be called last
        GUI.DragWindow();
    }

    void DrawNodeConnection(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 75;
        Vector3 endTan = endPos + Vector3.left * 75;

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.gray, null, 3);
    }
}
