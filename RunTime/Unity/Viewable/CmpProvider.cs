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
            var parnet = transform.parent;
            if (parnet != null)
            {
                UnityEditorInternal.ComponentUtility.CopyComponent(this);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(parnet.gameObject);
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
#if !UNITY_EDITOR|| RELEASE
            Destroy(this);
#endif
            return value;
        }
    }
}
