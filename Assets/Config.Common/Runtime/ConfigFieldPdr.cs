using System.Collections.Generic;
using System.Reflection;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class ConfigField : IComponent
	{
        public FieldInfo info;
	}
	public class ConfigFieldPdr: CmpProvider<ConfigField>
    {
        [HideInInspector] public string fieldName;
        [HideInInspector] public string typeName;
        public override IComponent GetValue()
        {
            ConfigTypeLoader.Load();
            if (ConfigTypeLoader.name2Fields.TryGetValue(typeName, out var fields))
            {
                var list = new List<string>();
                foreach (var item in fields)
                {
                    if(item.Name== fieldName)
                    {
                        value.info = item;
                        break;
                    }
                }
            }
            return base.GetValue();
        }
    }
#if UNITY_EDITOR
    [UnityEditor.CanEditMultipleObjects]
    [UnityEditor.CustomEditor(typeof(ConfigFieldPdr))]
    class ConfigFieldEditor : UnityEditor.Editor
    {
        int typeIdx = -1;
        string[] fieldNames;
        ConfigFieldPdr value;
        private void OnEnable()
        {
            value = target as ConfigFieldPdr;
            ConfigTypeLoader.Load();
            var type = value.GetComponentInParent<ConfigTypePdr>();
            if (type && !string.IsNullOrEmpty(type.typeName))
            {
                if (ConfigTypeLoader.name2Fields.TryGetValue(type.typeName, out var fields))
                {
                    var list = new List<string>();
                    foreach (var item in fields)
                    {
                        list.Add(item.Name);
                    }
                    fieldNames = list.ToArray();
                }
                value.typeName = type.typeName;
            }
            if (fieldNames != null)
            {
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    if (fieldNames[i] == value.fieldName)
                    {
                        typeIdx = i;
                        break;
                    }
                }
            }
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (fieldNames != null)
            {
                typeIdx = EditorHelper.Popup(typeIdx, fieldNames, "Select Field");

                if (typeIdx >= 0)
                    value.fieldName = fieldNames[typeIdx];
                if (GUI.changed)
                {
                    UnityEditor.EditorUtility.SetDirty(value);
                }
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
#endif
}
