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
                //if (parent != null)
                //    parent.childs.Add(tempEntity);
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
                //Debug.Log($"this::{this} cmp::{cmp} e::{tempEntity} parent::{tempEntity.parent} ");
                if (cmp != null)
                {
                    if (tempEntity != null)
                    {
                        if (tempEntity.Get<UnityEntity>() == null)
                            tempEntity.AddImpl<UnityEntity>(cmp);
                    }
                }
            }
        }
        protected string _Stack()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            var p = transform;
            while (p)
            {
                builder.Append(p.name);
                
                p = p.parent;
                if (p)
                    builder.Append("<-");
            }
            return builder.ToString();
        }
#if UNITY_EDITOR &&!RELEASE
        private void Update()
        {
            if (UnityEditor.EditorApplication.isPlaying)
                debugCondition = tree.Condition;
        }
#endif
#if UNITY_EDITOR
        internal readonly static Dictionary<Type, Type> cmp2pdr = new Dictionary<Type, Type>();
        
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
                            {
                                cmp2pdr.Add(key, item);
                              
                            }
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
        public virtual void DestroySelf()
        {
#if !UNITY_EDITOR || RELEASE
            Mgr.releases.Enqueue(this);
#endif
        }
    }
    public interface IFieldOverride
    {
        string fieldName { get; }
        Type OverrideType { get; }
    }
    //[ExecuteInEditMode]
    public abstract class TreeProvider<T> : TreeProvider where T : Tree, new()
    {
        public bool isTargetPriority;
        protected T value = new T();
        internal override Type TreeType() => typeof(T);
        public override ITree tree => value;
        Dictionary<string,Type> overrides;
        public override ITree GetTree()
        {
            //TakeAllCmps();
            value.entity = tempEntity;
            value.Name = gameObject.name;
            TrySetCallBack();
            SetFromTarget();
            DestroySelf();
            return value;
        }
        protected void SetFromTarget()
        {
            if (value is ATree tree)
            {
                tree.isTargetPriority = isTargetPriority;
            }
        }
        protected void TrySetCallBack()
        {
            if (value is ATree tree)
            {
                var ovds = GetComponents<IFieldOverride>();
                if (ovds.Length > 0)
                {
                    tree.onCmpFinding = (n, t) =>
                    {
                        if (overrides == null)
                        {
                            overrides = new Dictionary<string, Type>();
                            foreach (var item in ovds)
                            {
                                if (!string.IsNullOrEmpty(item.fieldName) && item.OverrideType != null)
                                {
                                    overrides.Add(item.fieldName, item.OverrideType);
                                }
                            }
                        }
                        if (overrides.TryGetValue(n, out var type))
                            return type;
                        return t;
                    };
                }
            }
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
        protected override bool isRename
        {
            get
            {
                if (gameObject.name != typeof(T).Name)
                    return false;
                return true;
            }
        }
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
                //Debug.Log($"c::{child.gameObject} cc::{child.gameObject.activeSelf}");
                if (child.gameObject.activeSelf)
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
    //[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    //public class MenualImpl : Attribute { }
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(TreeProvider), true)]
    class TreeProviderEditor : UnityEditor.Editor
    {
        List<FieldInfo> fields = new List<FieldInfo>();
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var tar = target as TreeProvider;
            LoadFields(tar, fields);
            for (int i = 0; i < fields.Count; i++)
            {
                var f = fields[i];
                UnityEditor.EditorGUILayout.LabelField($"{f.Name}:{f.FieldType}");
            }
        }

        public static void LoadFields(TreeProvider tar,List<FieldInfo> infos)
        {
            var type = tar.TreeType();
            if (type != null)
            {
                if (infos.Count == 0)
                {
                    foreach (var item in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                    {
                        if (typeof(IComponent).IsAssignableFrom(item.FieldType))
                        {
                            infos.Add(item);
                        }
                    }
                }
            }
        }
    }
#endif
}
