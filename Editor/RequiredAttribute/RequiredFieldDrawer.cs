using UnityEditor;
using UnityEngine;

namespace ZupEditorUtils
{
    [CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
    public class RequiredFieldDrawer : PropertyDrawer
    {
        static readonly Texture2D packageIcon =
            AssetDatabase.LoadAssetAtPath<Texture2D>
                ("Packages/net.thewazzzzzup.zuputils/Samples/RequiredEditorSample/orange-error-icon-0.png");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
     
            EditorGUI.BeginChangeCheck();

            Rect fieldRect = new(position.x, position.y, position.width - 20, position.height);
            EditorGUI.PropertyField(fieldRect, property, label);

            if (IsFieldUnassigned(property))
            {
                Rect iconRect = new(position.xMax - 18, fieldRect.y, 16, 16);
                GUI.Label(iconRect, new GUIContent(packageIcon, "This field is required and is either missing or empty"));
            }

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            
                EditorApplication.RepaintHierarchyWindow();
            }
        
            EditorGUI.EndProperty();
        }

        bool IsFieldUnassigned(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.ObjectReference when property.objectReferenceValue:
                case SerializedPropertyType.String when !string.IsNullOrEmpty(property.stringValue):
                case SerializedPropertyType.ExposedReference when property.exposedReferenceValue:
                    return false;
                default:
                    return true;
            
            }
        }
    }
}