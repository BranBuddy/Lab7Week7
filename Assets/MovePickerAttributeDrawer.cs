#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

#endif
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(MovePickerAttribute))]
public class MovePickerAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attr = (MovePickerAttribute)attribute;

        EditorGUI.BeginProperty(position, label, property);

        var propertyRect = new Rect(position.x, position.y, position.width - 20, position.height);
        var dropdownButtonRect = new Rect(propertyRect.xMax, position.y, 20, position.height);

        EditorGUI.PropertyField(propertyRect, property);

        if (GUI.Button(dropdownButtonRect, "..."))
        {
            var menu = new GenericMenu();
            foreach (var option in attr.options)
            {
                menu.AddItem(new GUIContent(option), false, () =>
                {
                    property.stringValue = option;

                    property.serializedObject.ApplyModifiedProperties();
                });


            }

            menu.ShowAsContext();

            EditorGUI.EndProperty();
        }

    }
}
#endif