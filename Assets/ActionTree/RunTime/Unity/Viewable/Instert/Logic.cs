using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class Logic : MonoBehaviour
    {
        [HideInInspector] public TreeProvider pdr;
        [HideInInspector] public List<LogicId> ids = new List<LogicId>();
        public Transform GetRef(int id)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                if (id == ids[i].id)
                    return ids[i].transform;
            }
            return null;
        }
        public int GetIndex(int id)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                if (id == ids[i].id)
                    return i;
            }
            return -1;
        }
        [HideInInspector] public int seed;
#if UNITY_EDITOR
        [ContextMenu("MarkId")]
        public void MarkId()
        {
            pdr = GetComponent<TreeProvider>();
            ids.Clear();
            Mark(transform);
            UnityEditor.EditorUtility.SetDirty(this);
        }
        void Mark(Transform transform)
        {
            for (int i = 0, c = transform.childCount; i < c; i++)
            {
                var child = transform.GetChild(i);
                var id = child.gameObject.GetComponent<LogicId>();
                if (!id)
                {
                    id = UnityEditor.Undo.AddComponent<LogicId>(child.gameObject);
                    id.hideFlags = HideFlags.HideInInspector;
                    id.id = seed++;
                    UnityEditor.EditorUtility.SetDirty(id);
                }
                ids.Add(id);
                Mark(child);
            }
        }
        [ContextMenu("RemoveId")]
        public void RemoveId()
        {
            UnityEditor.Undo.RegisterCompleteObjectUndo(this, "remove id");
            foreach (var item in ids)
            {
                UnityEditor.Undo.DestroyObjectImmediate(item);
            }
            ids.Clear();
            UnityEditor.EditorUtility.SetDirty(this);
        }
        
#endif
    }
}

