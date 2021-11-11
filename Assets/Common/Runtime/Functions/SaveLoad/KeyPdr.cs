using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using System;
using System.Reflection;

namespace ActionTree
{
	[System.Serializable]
	public sealed class Key : StringValue
	{
        //public string value;
	}
	public class KeyPdr: CmpProvider<Key>
    {
        public bool useKeyCollection;
        [HideInInspector]public string selectType;
        [HideInInspector] public string selectField;
    }
    [AttributeUsage( AttributeTargets.Class| AttributeTargets.Struct, AllowMultiple = false,Inherited = false)]
    public class KeyCollection : Attribute { }
    public class KeyColInfo
    {
        public string typeName;
        public List<string> fieldNames = new List<string>();
        public List<string> fieldValues = new List<string>();

        public static List<KeyColInfo> infos;
        public static void Load()
        {
            if (infos == null)
            {
                infos = new List<KeyColInfo>();
                //List<string> fs = new List<string>();
                foreach (var assembly in TreeDomain.workAssemblies)
                {
                    foreach (var item in assembly.GetTypes())
                    {
                        var kc = item.GetCustomAttribute<KeyCollection>();
                        if (kc != null)
                        {
                            KeyColInfo info = new KeyColInfo();
                            info.typeName = item.FullName;
                            //fs.Add(info.typeName);
                            foreach (var field in item.GetFields(BindingFlags.Static | BindingFlags.Public))
                            {
                                info.fieldNames.Add(field.Name);
                                info.fieldValues.Add((string)field.GetValue(null));
                            }
                            infos.Add(info);
                        }
                    }
                }
            }
        }
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(KeyPdr))]
    class KeyPdrEditor : UnityEditor.Editor
    {
        List<KeyColInfo> infos;
        static string[] fields;
        int selectType = -1;
        int selectField = -1;
        private void OnEnable()
        {
            KeyColInfo.Load();
            infos = KeyColInfo.infos;
            if (fields == null)
            {
                List<string> fs = new List<string>();
                for (int i = 0; i < infos.Count; i++)
                {
                    fs.Add(infos[i].typeName);
                }
                fields = fs.ToArray();
            }
            var tar = target as KeyPdr;
            for (int i = 0; i < infos.Count; i++)
            {
                var info = infos[i];
                if (info.typeName == tar.selectType)
                {
                    selectType = i;
                    for (int j = 0; j < info.fieldNames.Count; j++)
                    {
                        if (info.fieldNames[j] == tar.selectField)
                        {
                            selectField = j;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public override void OnInspectorGUI()
        {
            var k = target as KeyPdr;
            
            if (k.useKeyCollection)
            {
                k.useKeyCollection = UnityEditor.EditorGUILayout.Toggle("UseKeyCollection", k.useKeyCollection);
                if (infos.Count == 0)
                {
                    UnityEditor.EditorGUILayout.LabelField("KeyCollection not found");
                }
                else
                {
                    DrawInfo(k);
                }
            }
            else
            {
                base.OnInspectorGUI();
            }
            if (GUI.changed)
            {
                UnityEditor.EditorUtility.SetDirty(target);
            }
            serializedObject.ApplyModifiedProperties();
        }
        void DrawInfo(KeyPdr pdr)
        {
            int _selectType = EditorHelper.Popup(selectType, fields, "Select Collection");
            int _selectField = selectField;
            if (_selectType >= 0)
            {
                KeyColInfo info = infos[_selectType];
                pdr.selectType = info.typeName;
                _selectField = EditorHelper.Popup(selectField, info.fieldNames.ToArray(), "Select Key");
                if (_selectField >= 0)
                {
                    pdr.selectField = info.fieldNames[_selectField];
                    pdr.value.value = info.fieldValues[_selectField];
                    pdr.name = pdr.value.value;
                    //Debug.Log(pdr.value.value);
                }

            }
            if (_selectType != selectType || _selectField != selectField)
            {
                UnityEditor.EditorUtility.SetDirty(pdr);
            }
            selectType = _selectType;
            selectField = _selectField;
        }
    }
#endif
}
