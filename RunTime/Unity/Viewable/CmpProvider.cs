using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public abstract class CmpProvider : MonoBehaviour
    {
        public abstract IComponent GetValue();
        //public abstract IComponent Value { get; }
#if UNITY_EDITOR
        [ContextMenu("MoveToParent")]
        public void MoveToParent()
        {
            UnityEditor.Undo.IncrementCurrentGroup();
            var parnet = transform.parent;
            UnityEditor.Undo.RecordObject(parnet, "add cmp" + parnet);
            if (parnet != null)
            {
                var type = GetType();
                var cmp = parnet.GetComponent(type);
                if (cmp == null)
                    UnityEditor.Undo.AddComponent(parnet.gameObject, type);
               
                UnityEditor.Undo.DestroyObjectImmediate(this);
            }
        }
#endif
    }
    public abstract class CmpProvider<T> : CmpProvider where T : IComponent,new()
    {
        public T value = new T();
        //public override IComponent Value => value;
        public override IComponent GetValue()
        {
#if !UNITY_EDITOR
            Destroy(this);
#endif
            return value;
        }
    }
}
