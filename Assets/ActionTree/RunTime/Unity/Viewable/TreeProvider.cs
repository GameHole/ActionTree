using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace ActionTree
{ 
    public abstract class TreeProvider : MonoBehaviour
    {
#if UNITY_EDITOR && !RELEASE
        public bool debugCondition;
#endif
        public abstract ITree tree { get; }
        internal abstract Type TreeType();
        public abstract ITree GetTree();
        internal abstract ITree Clone();

        internal Entity tempEntity;
        bool isNewE;
        public virtual Entity MakeEntity(Entity parent)
        {
            var cmps = GetComponents<CmpProvider>();
            if (cmps.Length > 0)
            {
                tempEntity = new Entity();
                tempEntity.parent = parent;
                if (parent != null)
                    parent.childs.Add(tempEntity);
                isNewE = true;
                return tempEntity;
            }
            return tempEntity = parent;
        }
        
        public virtual void CollectComponent()
        {
            if (isNewE)
            {
                var cmps = GetComponents<CmpProvider>();
                for (int i = 0; i < cmps.Length; i++)
                {
                    tempEntity.Add(cmps[i].GetValue());
                }
                var cmp = GetComponent<UnityEntity>();
                if (cmp != null)
                {
                    if (tempEntity != null)
                    {
                        if (tempEntity.Get<UnityEntity>() == null)
                            tempEntity.Add(cmp);
                    }
                }
            }
        }
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
            var treeType = TreeType();
            if (treeType != null)
            {
                foreach (var item in treeType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    if (item.GetCustomAttribute<Finded>() != null) continue;
                    if (cmp2pdr.TryGetValue(item.FieldType, out var type))
                    {
                        if (!gameObject.GetComponent(type))
                            gameObject.AddComponent(type);
                    }
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
    public abstract class TreeProvider<T> : TreeProvider where T : Tree, new()
    {
        protected T value = new T();
        internal override Type TreeType() => typeof(T);
        public override ITree tree => value;
        public override ITree GetTree()
        {
            //TakeAllCmps();
            value.entity = tempEntity;
            DestroySelf();
            return value;
        }
        internal override ITree Clone()
        {
            var r = new T();
            r.entity = tempEntity;
            return r;
        }
    }
    
    public abstract class TreeCntrProvider<T> : TreeProvider<T> where T : ATreeCntr, new()
    {
        public override Entity MakeEntity(Entity parent)
        {
            var r = base.MakeEntity(parent);
            Foreach((item) =>
            {
                item.MakeEntity(r);
                //var e = item.MakeEntity(r);
                //if (e == null)
                //{
                //    item.tempEntity = r;
                //}
                //else
                //{
                //    e.parent = r;
                //    if (r != null)
                //    {
                //        r.childs.Add(e);
                //    }
                //}
            });
            return r;
        }
        public override void CollectComponent()
        {
            base.CollectComponent();
            Foreach((item) =>
            {
                item.CollectComponent();
            });
        }
        void Foreach(Action<TreeProvider> action)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);

                if (child.gameObject.activeInHierarchy)
                {
                    var item = child.GetComponent<TreeProvider>();
                    if (item)
                    {
                        action?.Invoke(item);
                        //var m = item.GetTree();
                        ////Debug.Log(m);
                        //value.Add(m);
                    }
                }
            }
        }
        public override ITree GetTree()
        {
            //TakeAllCmps();
            value.entity = tempEntity;
            Foreach((item) =>
            {
                var m = item.GetTree();
                //Debug.Log(m);
                value.Add(m);
            });
            DestroySelf();
            return value;
        }
        internal override ITree Clone()
        {
            var clone = new T();
            clone.entity = tempEntity;
            Foreach((item) =>
            {
                var m = item.Clone();
                //Debug.Log(m);
                clone.Add(m);
            });
            return clone;
        }
    }
}
