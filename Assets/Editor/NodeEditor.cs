using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow {

    List<Node> NodeList = new List<Node>();

    [MenuItem("Window/Node Editor")]
	public static void GetWindow()
    {
        EditorWindow.GetWindow<NodeEditor>();
    }

    void OnGUI()
    {
        for(int i = 0; i < NodeList.Count; i++)
        {
            for(int j = 0; j < NodeList[i].linkedNodes.Count; j++)
            {
                DrawNodeConnection(NodeList[i].rect, NodeList[i].linkedNodes[j].rect);
            }
        }

        if(NodeList.Count>1)
        {
            DrawNodeConnection(NodeList[0].rect, NodeList[1].rect);
        }
        if(GUILayout.Button("Add node"))
        {
            NodeList.Add(new Node(new Rect(10, 10, 100, 100), NodeList.Count));
            NodeList[NodeList.Count - 1].CloseFunction = RemoveNode;
        }
        BeginWindows();
        for(int i = 0; i < NodeList.Count; i++)
        {
            NodeList[i].rect = GUI.Window(i, NodeList[i].rect, NodeList[i].DrawGUI , NodeList[i].title);
        }
        EndWindows();
    }

    void DrawNodeWindow(int id)
    {
        //Color temp = GUI.backgroundColor;
        //GUI.backgroundColor = Color.red;
        //if(GUI.Button(new Rect(myRectList[id].rect.width - 18, -1, 18, 18), "X"))
        //{
        //    myRectList.RemoveAt(id);
        //}
        //GUI.backgroundColor = temp;

        ////once this is called it captures all user input, must be called last
        //GUI.DragWindow();
    }

    void DrawNodeConnection(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 75;
        Vector3 endTan = endPos + Vector3.left * 75;

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.gray, null, 3);
    }

    public void RemoveNode(Node node)
    {
        for(int i = 0; i < NodeList.Count; i++)
        {
            for(int j = 0; j < NodeList[i].linkedNodes.Count; j++)
            {
                if(NodeList[i].linkedNodes[j].id == node.id)
                {
                    NodeList[i].linkedNodes.RemoveAt(j);
                }
            }
        }
        NodeList.RemoveAt(node.id);
        ReassignNodes();
    }

    public void ReassignNodes()
    {
        for(int i=0; i < NodeList.Count; i++)
        {
            NodeList[i].id = i;
        }
    }
}
