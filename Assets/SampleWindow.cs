using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SampleWindow : EditorWindow {

    public string[] strArray = { "one", "two", "three", "four" };
    public int selectRoyce = 0;
    public string s1 = "";
    public float f1, f2, f3, f4;
    public bool myBool = false;

    public Texture myTexture;
    public GUISkin mySkin;

    [MenuItem("cw/sw")]
    static void DisplayWindow()
    {
        GetWindow<SampleWindow>(true);
    }

    void OnEnable()
    {
        myTexture = EditorGUIUtility.Load("Blur.jpg") as Texture;
        mySkin = EditorGUIUtility.Load("ms.guiskin") as GUISkin;
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        GUI.DrawTexture(new Rect(0, 0, position.width, position.height), myTexture);
        GUILayout.Space(10);
        GUILayout.Label(s1);
        GUILayout.Space(10);
        s1 = GUILayout.TextField(s1);
        GUILayout.Space(10);
        selectRoyce = EditorGUILayout.IntSlider(selectRoyce, 0, 10);
        GUILayout.Space(10);
        f1 = EditorGUILayout.FloatField(f1, mySkin.GetStyle("textfield"));
        GUILayout.Space(10);
        if (GUILayout.Button("Button"))
        {
            myBool = !myBool;
        }
        GUILayout.Space(10);
        myBool = EditorGUILayout.Toggle(myBool, mySkin.GetStyle("checkbox"));
    }
}
