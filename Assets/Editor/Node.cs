using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int id;
    public Rect rect;
    public string title = "";

    public delegate void voidNodeFunction(Node node);//decflaration of what the delegate is

    public voidNodeFunction CloseFunction;//the actual delegate

    public List<Node> linkedNodes = new List<Node>();

    public Node(Rect r, int i)
    {
        id = i;
        rect = r;
    }

    public Node(Rect r, int i, string s)
    {
        id = i;
        rect = r;
        title = s;
    }

    public void BaseDraw(int winID)
    {
        Color temp = GUI.backgroundColor;
        GUI.backgroundColor = Color.red;
        if (GUI.Button(new Rect(rect.width - 18, -1, 18, 18), "X"))
        {
            CloseFunction(this);
        }
        GUI.backgroundColor = temp;

        //once this is called it captures all user input, must be called last
        GUI.DragWindow();
    }

    public virtual void DrawGUI(int winID)
    {
        GUILayout.Label("NodeID: " + winID);
        BaseDraw(winID);
    }

    public virtual void AttachNode(Node node)
    {
        linkedNodes.Add(node);
    }
}
