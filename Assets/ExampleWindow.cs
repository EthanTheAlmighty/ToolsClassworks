using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow {

    public string[] strArray = { "one", "two", "three", "four" };
    public int selectRoyce = 0;
    public string s1 = "";
    public float f1, f2, f3, f4;

    [MenuItem("Custom Tools/Example Window")]
	static void DisplayWindow()
    {
        GetWindow<ExampleWindow>();
    }

    void OnGUI()
    {
        float columnSize = position.width/10;

        GUILayout.Label("Example Window");
        s1 = GUILayout.TextField(s1);

        GUILayout.Space(10);

        GUILayout.Label("Sliders");

        GUILayout.BeginHorizontal();
        GUILayout.Label("f1", GUILayout.MaxWidth(columnSize/2));
        f1 = GUILayout.HorizontalSlider(f1, 0, 10);
        f1 = EditorGUILayout.FloatField(f1, GUILayout.MaxWidth(columnSize));
        GUILayout.Label("f3", GUILayout.MaxWidth(columnSize / 2));
        f3 = GUILayout.HorizontalSlider(f3, 0, 10);
        f3 = EditorGUILayout.FloatField(f3, GUILayout.MaxWidth(columnSize));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("f2", GUILayout.MaxWidth(columnSize / 2));
        f2 = GUILayout.HorizontalSlider(f2, 0, 10);
        f2 = EditorGUILayout.FloatField(f2, GUILayout.MaxWidth(columnSize));
        GUILayout.Label("f4", GUILayout.MaxWidth(columnSize / 2));
        f4 = GUILayout.HorizontalSlider(f4, 0, 10);
        f4 = EditorGUILayout.FloatField(f4, GUILayout.MaxWidth(columnSize));
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        selectRoyce = GUILayout.SelectionGrid(selectRoyce, strArray, 4);
    }
}
