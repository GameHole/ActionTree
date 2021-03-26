using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{ 
    public abstract class TreeProvider : MonoBehaviour
    {

#if UNITY_EDITOR && !RELEASE
        public bool debugCondition;
#endif
        //public bool isMainThread;
        public abstract ITree tree { get; }
        internal abstract Type TreeType();
        public abstract ETree GetTree();
#if UNITY_EDITOR &&!RELEASE
        private void Update()
        {
            if (UnityEditor.EditorApplication.isPlaying)
                debugCondition = tree.Condition;
        }
#endif
#if UNITY_EDITOR
        protected readonly static Dictionary<Type, Type> cmp2pdr = new Dictionary<Type, Type>();
        static bool inited;
        public void AddCmps()
        {
            if (!inited)
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (var item in assembly.GetTypes())
                    {
                        if (item.BaseType == null || item.IsAbstract || !item.BaseType.IsGenericType) continue;
                        if (typeof(CmpProvider).IsAssignableFrom(item.BaseType))
                        {
                            var key = item.BaseType.GetGenericArguments()[0];
                            cmp2pdr.Add(key, item);
                        }
                    }
                }
                inited = true;
            }
            foreach (var item in TreeType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
                if (cmp2pdr.TryGetValue(item.FieldType, out var type))
                {
                    gameObject.AddComponent(type);
                }
            }
        }
#endif
        public void DestroySelf()
        {
#if !UNITY_EDITOR || RELEASE
            Mgr.releases.Enqueue(this);
#endif
        }
    }
    [ExecuteInEditMode]
    public abstract class TreeProvider<T> : TreeProvider where T : ETree, new()
    {
        protected T value = new T();
        internal override Type TreeType() => typeof(T);
        public override ITree tree => value;
        protected void TakeAllCmps()
        {
            var cmps = GetComponents<CmpProvider>();
            for (int i = 0; i < cmps.Length; i++)
            {
                value.Add(cmps[i].GetValue());
            }
            var cmp = GetComponent<IComponent>();
            if (cmp != null)
            {
                //Debug.Log(cmp);
                value.Add(cmp);
            }
        }
        public override ETree GetTree()
        {
            TakeAllCmps();

            DestroySelf();


            return value;
        }
    }
    //public abstract class ManualConditionProvider<T> : TreeProvider<T> where T : ATree, new()
    //{
    //    public bool MenuCondition;
    //    public override ITree GetTree()
    //    {
    //        value.Condition = MenuCondition;
    //        return base.GetTree();
    //    }
    //}
    public abstract class TreeCntrProvider<T> : TreeProvider<T> where T : ATreeCntr, new()
    {
        public override ETree GetTree()
        {
            TakeAllCmps();
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);

                if (child.gameObject.activeInHierarchy)
                {
                    var item = child.GetComponent<TreeProvider>();
                    if (item)
                    {
                        var m = item.GetTree();
                        //Debug.Log(m);
                        value.Add(m);
                    }
                }
            }
            DestroySelf();
            return value;
        }
    }
}
