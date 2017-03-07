using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomObjectAttribute : PropertyAttribute {
    public CustomObjectAttribute() { }
}

[CustomPropertyDrawer(typeof(CustomObjectAttribute))]
public class CustomObjectDrawer:PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 4;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        Rect drawRect = position;
        drawRect.height /= 4;

        EditorGUI.PropertyField(drawRect, property, label);

        drawRect.y += drawRect.height;
        GameObject myGO = property.objectReferenceValue as GameObject;

        if (property.objectReferenceValue != null)
        {
            float myFloat = myGO.transform.localScale.x;
            myFloat = EditorGUI.Slider(drawRect, "Scale", myFloat, 1, 10);
            myGO.transform.localScale = new Vector3(myFloat, myFloat, myFloat);

            drawRect.y += drawRect.height;
            myGO.transform.position = EditorGUI.Vector3Field(drawRect, "Position", myGO.transform.position);
        }
    }
}
