using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace ActionTree
{
    public class TreeInserter : MonoBehaviour
    {
        public enum InsertType
        {
            Replace = 0, After = 1, Before = -1
        }
        public InsertType insertType = InsertType.After;
        [HideInInspector] public int classRefId;
        public void InjectLogic(Logic logic)
        {
            var pdr = GetComponent<TreeProvider>();
            if (pdr)
            {
                var classRef = logic.GetRef(classRefId);
                if (classRef)
                {
                    pdr.transform.parent = classRef.parent;
                    var index = classRef.GetSiblingIndex();
                    classRef.gameObject.SetActive(insertType != InsertType.Replace);
                    pdr.transform.SetSiblingIndex(index + 1 * (int)insertType);
                }
            }
            //Destroy(this);
        }
    }
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(TreeInserter))]
    class TreeInserterEditor : UnityEditor.Editor
    {
        string[] names;
        int select;
        int preSelect;
        Logic logic;
        private void OnEnable()
        {
            var inster = target as TreeInserter;
            logic = GetComponentInParent<LogicPrevider>(inster.transform).prefab;
            if (logic)
            {
                preSelect = select = logic.GetIndex(inster.classRefId);
            }
        }
        T GetComponentInParent<T>(Transform transform)where T:Component
        {
            var p = transform.parent;
            while (p)
            {
                var t = p.GetComponent<T>();
                if (t) return t;
                p = p.parent;
            }
            return null;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var inster = target as TreeInserter;
            LoadNames(inster);
            if (names != null)
            {
                UnityEditor.EditorGUILayout.BeginHorizontal();
                UnityEditor.EditorGUILayout.LabelField("Insert To");
                select = UnityEditor.EditorGUILayout.Popup(select, names);
                UnityEditor.EditorGUILayout.EndHorizontal();
            }
            if (preSelect != select)
            {
                if (logic)
                    inster.classRefId = logic.ids[select].id;
                UnityEditor.EditorUtility.SetDirty(inster);
                preSelect = select;
            }
            serializedObject.ApplyModifiedProperties();
        }
        void LoadNames(TreeInserter inster)
        {
            if (logic)
            {
                names = new string[logic.ids.Count];
                for (int i = 0; i < logic.ids.Count; i++)
                {
                    names[i] = getName(logic.ids[i].transform);
                }
            }
        }
        string getName(Transform transform)
        {
            StringBuilder builder = new StringBuilder();
            var p = transform;
            while (true)
            {
                builder.Append(p.name);
                p = p.parent;
                if (p == null)
                    break;
                builder.Append("<-"); 
            }
            //builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
        }
    }
#endif
}

