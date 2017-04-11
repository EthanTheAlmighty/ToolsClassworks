using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class reflection : EditorWindow {
    public GameObject go;
    public Component targetComp;

    public int goSelected = 0;
    public int methSelected = 0;

    List<Component> comp = new List<Component>();
    List<MethodInfo> methods = new List<MethodInfo>();
    List<string> methNames = new List<string>();
    List<string> comNames = new List<string>();


    [MenuItem("Window/reflectivity")]
    public static void  ShowWindow()
    {
        GetWindow<reflection>();
    }

    public void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        go = (GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), true);
        if(EditorGUI.EndChangeCheck())
        {
            
            comNames.Clear();
            comp = new List<Component>(go.GetComponents(typeof(Component)));
            foreach(Component c in comp)
            {
                comNames.Add(c.GetType().Name);

            }
        }
        if(go != null)
        {
            if(comNames.Count > 0)
            {
                EditorGUI.BeginChangeCheck();
                goSelected = EditorGUILayout.Popup(goSelected, comNames.ToArray());
                if(EditorGUI.EndChangeCheck())
                {
                    methNames.Clear();
                    targetComp = comp[goSelected];
                    BindingFlags flags = BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;

                    methods = new List<MethodInfo>(targetComp.GetType().GetMethods(flags));
                    foreach(MethodInfo me in methods)
                    {
                        methNames.Add(me.Name);
                        //Debug.Log("Fire");
                    }
                }

                if(methNames.Count > 0)
                {
                    methSelected = EditorGUILayout.Popup(methSelected, methNames.ToArray());
                    if(GUILayout.Button("Run " + methNames[methSelected]))
                    {
                        methods[methSelected].Invoke(targetComp, null);
                    }
                }
            }
        }
        
    }
	
}
