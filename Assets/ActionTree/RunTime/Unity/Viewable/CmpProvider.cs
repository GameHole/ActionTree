using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public abstract class CmpProvider : MonoBehaviour
    {
        public abstract object GetValue();
    }
    public abstract class CmpProvider<T> : CmpProvider where T : IComponent,new()
    {
        public T value = new T();
        public override object GetValue()
        {
#if !UNITY_EDITOR
            Destroy(this);
#endif
            return value;
        }
    }
}
