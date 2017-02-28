using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(TimeFormatAttribute))]
public class TimeFormatDrawer : PropertyDrawer{

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label)*2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        if(property.propertyType == SerializedPropertyType.Integer)
        {
            //EditorGUIUtility.labelWidth = 8 * label.text.Length;

            Rect drawingPos = position;
            drawingPos.height /= 2;
            property.intValue = EditorGUI.IntField(drawingPos, label, Mathf.Max(1, property.intValue));

            drawingPos.y += drawingPos.height;
            EditorGUI.LabelField(drawingPos, " ", ConvertTime(property.intValue));
        }
        else
        {
            EditorGUI.HelpBox(position, "To use the TimeFormat attribute " + label.text + " must be an int!", MessageType.Error);
        }
    }

    public string ConvertTime(int s)
    {
        TimeFormatAttribute timeAtt = attribute as TimeFormatAttribute;

        if(timeAtt.DisplayHours)
        {
            int hours = s / 3600;
            int minutes = ((s % (3600)) / 60);
            int seconds = (s % 60);
            return string.Format("{0}:{1}:{2} (h:mm:ss)", hours, minutes.ToString().PadLeft(2,'0'), seconds.ToString().PadLeft(2, '0'));
        }
        else
        {
            int minutes = (s / 60);
            int seconds = (s % 60);
            return string.Format("{0}:{1} (mm:ss)", minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
        }
    }
}
