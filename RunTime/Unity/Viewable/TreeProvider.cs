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
                            if (!cmp2pdr.ContainsKey(key))
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
                if (isRename)
                    gameObject.name = treeType.Name;
            }
        }
#endif
        protected virtual bool isRename { get => true; }
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
            value.Name = gameObject.name;
            DestroySelf();
            return value;
        }
        internal override ITree Clone()
        {
            var r = new T();
            r.Name = gameObject.name;
            r.entity = tempEntity;
            return r;
        }
    }
    
    public abstract class TreeCntrProvider<T> : TreeProvider<T> where T : ATreeCntr, new()
    {
        protected override bool isRename => false;
        public override Entity MakeEntity(Entity parent)
        {
            var r = base.MakeEntity(parent);
            Foreach((item) =>
            {
                item.MakeEntity(r);
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
            value.Name = gameObject.name;
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
            clone.Name = gameObject.name;
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
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(TreeProvider), true)]
    class RotateDirctionLeafEditor : UnityEditor.Editor
    {
        List<FieldInfo> fields = new List<FieldInfo>();
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var tar = target as TreeProvider;
            if (fields.Count == 0)
            {
                foreach (var item in tar.TreeType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    if (typeof(IComponent).IsAssignableFrom(item.FieldType))
                        fields.Add(item);
                }
            }
            for (int i = 0; i < fields.Count; i++)
            {
                var f = fields[i];
                UnityEditor.EditorGUILayout.LabelField($"{f.Name}:{f.FieldType}");
            }
        }
    }
#endif
}
