using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ZupEditorUtils
{
    [InitializeOnLoad]
    public static class HierarchyIconDrawer
    {
        static readonly Texture2D packageIcon =
            AssetDatabase.LoadAssetAtPath<Texture2D>
                ("Packages/net.thewazzzzzup.zuputils/Samples/RequiredEditorSample/orange-error-icon-0.png");

        private static readonly Dictionary<Type, FieldInfo[]> cachedFieldInfo = new();

        static HierarchyIconDrawer()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemGUI;
        }

        private static void OnHierarchyWindowItemGUI(int instanceId, Rect selectionRect)
        {
            if (EditorUtility.InstanceIDToObject(instanceId) is not GameObject gameObject) return;

            foreach (var component in gameObject.GetComponents<Component>())
            {
                if (component == null) continue;

                var fields = GetCachedFieldsWithRequiredAttribute(component.GetType());
                if (fields == null) continue;

                if (fields.Any(field => IsFieldUnassigned(field.GetValue(component))))
                {
                    var iconRect = new Rect(selectionRect.xMax - 20, selectionRect.y, 16, 16);
                    GUI.Label(iconRect, new GUIContent(packageIcon,"One or more required fields are missing or empty"));
                    break;
                }
            }
        }

        static FieldInfo[] GetCachedFieldsWithRequiredAttribute(Type componentType)
        {
            if (!cachedFieldInfo.TryGetValue(componentType, out FieldInfo[] fields))
            {
                fields = componentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                List<FieldInfo> requiredFields = new();

                foreach (var field in fields)
                {
                    bool isSeralized = field.IsPublic || field.IsDefined(typeof(SerializeField), false);
                    bool isRequired = field.IsDefined(typeof(RequiredFieldAttribute), false);

                    if (isSeralized && isRequired)
                    {
                        requiredFields.Add(field);
                    }

                    fields = requiredFields.ToArray();
                    cachedFieldInfo[componentType] = fields;
                }
            }

            return fields;
        }
    
        static bool IsFieldUnassigned(object fieldValue)
        {
            if (fieldValue == null) return true;
        
            if (fieldValue is string stringValue && string.IsNullOrEmpty(stringValue)) return true;

            if (fieldValue is System.Collections.IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (item == null) return true;
                }
            }

            return false;
        }
    }
}