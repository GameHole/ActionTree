using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class ConfigType : IComponent
	{
        public Type type;
	}
	public class ConfigTypePdr: CmpProvider<ConfigType>
    {
        [HideInInspector]public string typeName;
        public override IComponent GetValue()
        {
            ConfigTypeLoader.Load();
            if(ConfigTypeLoader.name2Type.TryGetValue(typeName,out var type))
            {
                value.type = type;
            }
            return base.GetValue();
        }
    }
#if UNITY_EDITOR
    [UnityEditor.CanEditMultipleObjects]
    [UnityEditor.CustomEditor(typeof(ConfigTypePdr))]
    class ConfigTypeEditor : UnityEditor.Editor
    {
        int typeIdx = -1;
        string[] typeNames;
        ConfigTypePdr value;
        private void OnEnable()
        {
            value = target as ConfigTypePdr;
            ConfigTypeLoader.Load();
            typeNames = ConfigTypeLoader.name2Type.Keys.ToArray();
            for (int i = 0; i < typeNames.Length; i++)
            {
                if (typeNames[i] == value.typeName)
                {
                    typeIdx = i;
                    break;
                }
            }
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            typeIdx = EditorHelper.Popup(typeIdx, typeNames, "Select Config Type");
            if (typeIdx >= 0)
                value.typeName = typeNames[typeIdx];
            if (GUI.changed)
            {
                UnityEditor.EditorUtility.SetDirty(value);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
    static class ConfigTypeLoader
    {
        static bool isLoaded;
        internal static Dictionary<string, Type> name2Type = new Dictionary<string, Type>();
        internal static Dictionary<string, FieldInfo[]> name2Fields = new Dictionary<string, FieldInfo[]>();
        public static void Load()
        {
            if (isLoaded) return;
            isLoaded = true;
            foreach (var assembly in TreeDomain.workAssemblies)
            {
                foreach (var item in assembly.GetTypes())
                {
                    if (item.IsAbstract || item.IsInterface || item.IsValueType) continue;
                    if (typeof(IConfigValue).IsAssignableFrom(item))
                    {
                        name2Type.Add(item.FullName, item);
                        name2Fields.Add(item.FullName, item.GetFields());
                    }
                }
            }
        }
    }
}
