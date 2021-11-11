using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public abstract class CmpProvider : MonoBehaviour
    {
        public abstract IComponent GetValue();
        public abstract Type CmpType();
#if UNITY_EDITOR
        public abstract IComponent Value { get; }
        [ContextMenu("MoveToParent")]
        public void MoveToParent()
        {
            var parnet = transform.parent;
            if (parnet != null)
            {
                UnityEditorInternal.ComponentUtility.CopyComponent(this);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(parnet.gameObject);
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    UnityEditor.Undo.DestroyObjectImmediate(this);
                };
            }
        }
#endif
    }
    public abstract class CmpProvider<T> : CmpProvider where T : IComponent,new()
    {
        public T value = new T();
        public override Type CmpType() => typeof(T);
        protected virtual bool DestroySelfWhenInReleaseMode => true;
#if UNITY_EDITOR
        public override IComponent Value => value;
#endif
        public override IComponent GetValue()
        {
#if !UNITY_EDITOR || RELEASE
            if (DestroySelfWhenInReleaseMode)
                Destroy(this);
#endif
            return value;
        }
    }
}
