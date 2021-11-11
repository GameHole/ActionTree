using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
namespace ActionTree
{
    public class OverrideField : MonoBehaviour, IFieldOverride
    {
        
        public Type OverrideType { get; set; }

        public string fieldName { get=> _fieldName; }

        private void Awake()
        {
            Init();
            if (name2Type.TryGetValue(ovdType, out var type))
                OverrideType = type;
        }
        internal static Dictionary<string, Type> name2Type;
        internal static void Init()
        {
            if (name2Type == null)
            {
                name2Type = new Dictionary<string, Type>();
                foreach (var assembly in TreeDomain.workAssemblies)
                {
                    foreach (var item in assembly.GetTypes())
                    {
                        if (item.IsAbstract || item.IsInterface || item.IsValueType) continue;
                        if (typeof(IComponent).IsAssignableFrom(item))
                        {
                            name2Type.Add(item.FullName, item);
                        }
                    }
                }
            }
        }
        [HideInInspector] public string _fieldName;
        [HideInInspector] public string ovdType;
    }
#if UNITY_EDITOR
    [UnityEditor.CanEditMultipleObjects]
    [UnityEditor.CustomEditor(typeof(OverrideField))]
    class OveridderEditor : UnityEditor.Editor
    {
        int selectOvder;
        int selectField = -1;
        List<FieldInfo> fields = new List<FieldInfo>();
        List<string> names = new List<string>();
        List<string> vs = new List<string>();
        private void OnEnable()
        {
            OverrideField.Init();
            var odr = target as OverrideField;
            if (LoadFields())
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (odr._fieldName == names[i])
                    {
                        selectField = i;
                        break;
                    }
                }
                LoadTypes();
                for (int i = 0; i < vs.Count; i++)
                {
                    if (odr.ovdType == vs[i])
                    {
                        selectOvder = i;
                        break;
                    }
                }
            }
        }
        bool LoadFields()
        {
            var t = (target as OverrideField).GetComponent<TreeProvider>();
            if (t)
            {
                TreeProviderEditor.LoadFields(t, fields);
                names.Clear();
                for (int i = 0; i < fields.Count; i++)
                {
                    names.Add(fields[i].Name);
                }
                return true;
            }
            return names.Count > 0;
        }
        void LoadTypes()
        {
            vs.Clear();
            if (selectField >= 0)
            {
                var finfo = fields[selectField];
                foreach (var item in OverrideField.name2Type.Values)
                {
                    var t = finfo.FieldType;
                    if (t.IsArray)
                        t = t.GetElementType();
                    if (t.IsAssignableFrom(item))
                        vs.Add(item.FullName);
                }
            }
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (LoadFields())
            {
                LoadTypes();
                UnityEditor.EditorGUILayout.BeginVertical();
                int last = EditorHelper.Popup(selectField, names.ToArray(), "Select Field");
                selectOvder = EditorHelper.Popup(selectOvder, vs.ToArray(), "Select Override Type");
                UnityEditor.EditorGUILayout.EndVertical();
                if (last != selectField)
                {
                    selectOvder = 0;
                }
                selectField = last;
                var odr = target as OverrideField;
                if (selectField >= 0)
                    odr._fieldName = names[selectField];
                if (vs.Count > selectOvder)
                    odr.ovdType = vs[selectOvder];
                if (GUI.changed)
                {
                    UnityEditor.EditorUtility.SetDirty(odr);
                }
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
#endif
}
