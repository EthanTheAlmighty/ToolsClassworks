using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelInspector : Editor {

    Level _RoyceLevel;

    private int _width;
    private int _height;

    private bool _RoyceToggle;

    private SerializedObject _mySerializedObject;
    private SerializedProperty _mySerializedeProperty;
	private void OnEnable()
    {
        _RoyceLevel = (Level)target;
        _mySerializedObject = new SerializedObject(_RoyceLevel);
        _mySerializedeProperty = _mySerializedObject.FindProperty("timeAllowed");

        GetSizeValues();
    }

    private void GetSizeValues()
    {
        _width = _RoyceLevel.width;
        _height = _RoyceLevel.height;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawLevelData();
        DrawGameObjectFields();
        DrawSizeData();
    }

    private void DrawLevelData()
    {
        EditorGUILayout.LabelField("Data", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        //_RoyceLevel.timeAllowed = EditorGUILayout.IntField("Time Allowed", Mathf.Max(1, _RoyceLevel.timeAllowed));
        EditorGUILayout.PropertyField(_mySerializedeProperty);
        _RoyceLevel.gravity = EditorGUILayout.FloatField("Gravity", _RoyceLevel.gravity);
        EditorGUILayout.EndVertical();
    }

    private void DrawGameObjectFields()
    {
        _RoyceToggle = EditorGUILayout.Foldout(_RoyceToggle, "Game Objects");
        if(_RoyceToggle)
        {
            EditorGUILayout.BeginVertical("Button");
            _RoyceLevel.top = (GameObject)EditorGUILayout.ObjectField("Top", _RoyceLevel.top, typeof(GameObject), true);
            _RoyceLevel.bottom = (GameObject)EditorGUILayout.ObjectField("Bottom", _RoyceLevel.bottom, typeof(GameObject), true);
            _RoyceLevel.left = (GameObject)EditorGUILayout.ObjectField("Left", _RoyceLevel.left, typeof(GameObject), true);
            _RoyceLevel.right = (GameObject)EditorGUILayout.ObjectField("Right", _RoyceLevel.right, typeof(GameObject), true);
            EditorGUILayout.EndVertical();
        }
    }

    private void DrawSizeData()
    {
        EditorGUILayout.LabelField("Size", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal("box");
        EditorGUILayout.BeginVertical("box");
        _width = EditorGUILayout.IntField("Width", Mathf.Max(1,_width));
        _height = EditorGUILayout.IntField("Height", Mathf.Max(1, _height));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        GUI.enabled = (_width != _RoyceLevel.width || _height != _RoyceLevel.height);

        bool resize = GUILayout.Button("Resize", GUILayout.Height(EditorGUIUtility.singleLineHeight * 2));
        if(resize)
        {
            HandleDialogue();
        }
        bool resetButton = GUILayout.Button("Reset");
        if(resetButton)
        {
            GetSizeValues();
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }

    private void HandleDialogue()
    {
        if (EditorUtility.DisplayDialog(
            "Level Resize",
            "Are you sure you want to resize?\nThis action can not be undone.",
            "Yes",
            "No"
            )) ;
        {
            CallResize();
        }
    }

    private void CallResize()
    {
        _RoyceLevel.width = _width;
        _RoyceLevel.height = _height;
        _RoyceLevel.ResizeLevel();
    }
}
