using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActionTree
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class AllowNull : Attribute { }
    public class CmpFindingInfo
    {
        public Type type;
        public bool containThis = true;
    }
    public static class TreeInfo
    {
        public class Info
        {
            public List<FieldInfo> findedFields = new List<FieldInfo>();
            public List<FieldInfo> cmpFields = new List<FieldInfo>();
            public List<FieldInfo> cmpArrayFields = new List<FieldInfo>();
        }
        static Dictionary<Type, Info> fields = new Dictionary<Type, Info>();
        internal static bool TryGetFieldInfo(Type type,out Info info)
        {
            return fields.TryGetValue(type, out info);
        }
        public static IEnumerable<Type> GetTypes()
        {
            return fields.Keys;
        }
        public static IEnumerable<KeyValuePair<Type, Info>> GetItems()
        {
            return fields;
        }
        static TreeInfo()
        {
            foreach (var assembly in TreeDomain.workAssemblies)
            {
                foreach (var treeType in assembly.GetTypes())
                {
                    if (treeType.IsValueType || treeType.IsAbstract || !typeof(ITree).IsAssignableFrom(treeType)) continue;
                    var info = new Info();
                    foreach (var field in treeType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                    {
                        var ft = field.FieldType;
                        if (ft.IsAbstract | ft.IsValueType) continue;
                        var find = field.GetCustomAttribute<Finded>();
                        if (find != null && typeof(IComponent).IsAssignableFrom(ft))
                        {
                            info.findedFields.Add(field);
                            if (find.types != null)
                            {
                                find.types.Add(ft);
                            }
                        }
                        else
                        {
                            if (ft.IsArray)
                            {
                                var type = ft.GetElementType();
                                if (typeof(IComponent).IsAssignableFrom(type))
                                {
                                    info.cmpArrayFields.Add(field);
                                }
                            }
                            else
                            {
                                if (typeof(IComponent).IsAssignableFrom(ft))
                                {
                                    info.cmpFields.Add(field);
                                }
                            }
                        }
                    }
                    fields.Add(treeType, info);
                }
            }
        }
    } 
    public abstract class ATree : Tree
    {
        public static float deltaTime { get; internal set; }
        public Driver driver;
        internal List<FieldInfo> needFindInfo;
        internal Func<string,Type, Type> onCmpFinding;
        internal bool isTargetPriority;
        //public Func<FieldInfo,Entity, IComponent> onNotFoundComponent; 
        public override void Clear()
        {
            Condition = false;
        }
        protected void ReApply()
        {
            ITree p = parent;
            var root = p;
            while (p != null)
            {
                root = p;
                p = p.parent;
            }
            if (root != null)
                root.Apply();
        }
        public override void Apply()
        {
            optimizedReflect();
            //reflect();
        }
        void optimizedReflect()
        {
            //UnityEngine.Debug.Log($"reflect {GetType()}");
            if (!TreeInfo.TryGetFieldInfo(GetType(),out var info))
            {
                throw new Exception($"type::{GetType()} info not found");
            }
            if (info.findedFields.Count > 0)
            {
                needFindInfo = new List<FieldInfo>();
                needFindInfo.AddRange(info.findedFields);
                //foreach (var item in needFindInfo)
                //{
                //    UnityEngine.Debug.Log($"find ::{item}");
                //}
            }
            foreach (var item in info.cmpFields)
            {
                injectCmp(item);
                //UnityEngine.Debug.Log($"cmpFields ::{item}");
            }
            foreach (var item in info.cmpArrayFields)
            {
                //UnityEngine.Debug.Log($"cmpArrayFields ::{item}");
                injectCmpArray(item);
            }
        }
        void injectCmp(FieldInfo item)
        {
            var ft = item.FieldType;
            //var tarAttr = item.GetCustomAttribute<NotThis>();
            bool containThis = true;// tarAttr == null;
            if (onCmpFinding != null)
            {
                try
                {
                    ft = onCmpFinding(item.Name, ft);
                }
                catch (Exception e)
                {
                    throw new Exception(this.stack(), e);
                }
            }
            IComponent cmp = null;
            if (isTargetPriority)
            {
                cmp = FindFromTarget(ft);
                if (cmp == null)
                    cmp = entity.FindComponent(ft, containThis);
            }
            else
            {
                cmp = entity.FindComponent(ft, containThis);
                if (cmp == null)
                {
                    cmp = FindFromTarget(ft);
                }
            }
            if (cmp == null)
            {
                if (item.GetCustomAttribute<AllowNull>() == null)
                    throw new NullReferenceException($"Inject component <{ft}:{item.Name}> not found anywhere,please add <{ft}> compoennt to leaf or add [AllowNull] attribute to field \nRoute:{this.stack()} ");
            }
            item.SetValue(this, cmp);
        }
        void injectCmpArray(FieldInfo item)
        {
            var type = item.FieldType.GetElementType();
            if (onCmpFinding != null)
            {
                type = onCmpFinding(item.Name, type);
            }
            var list = entity.FindAll(type);
            var array = Array.CreateInstance(type, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                array.SetValue(list[i], i);
            }
            item.SetValue(this, array);
        }
        void reflect()
        {
            foreach (var item in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var ft = item.FieldType;
                if (ft.IsAbstract | ft.IsValueType) continue;
                var find = item.GetCustomAttribute<Finded>();
                //if(find!=null)
                    //this.Log($"{GetType()}.{item}");
                if (find != null && typeof(IComponent).IsAssignableFrom(ft))
                {
                    if (needFindInfo == null)
                        needFindInfo = new List<FieldInfo>();
                    needFindInfo.Add(item);
                    if (find.types != null)
                    {
                        find.types.Add(item.FieldType);
                    }
                    //this.Log($"t {item} c {needFindInfo.Count}");
                }
                else
                {
                    injectdata(item);
                }
            }

        }
        void injectdata(FieldInfo item)
        {
            if (entity == null) return;
            var ft = item.FieldType;
            if (ft.IsArray)
            {
                var type = ft.GetElementType();
                if (typeof(IComponent).IsAssignableFrom(type))
                {
                    if (onCmpFinding != null)
                    {
                        type = onCmpFinding(item.Name, type);
                    }
                    var list = entity.FindAll(type);
                    var array = Array.CreateInstance(type, list.Count);
                    for (int i = 0; i < list.Count; i++)
                    {
                        array.SetValue(list[i], i);
                    }
                    item.SetValue(this, array);
                }
            }
            else
            {
                if (typeof(IComponent).IsAssignableFrom(ft))
                {
                    var tarAttr = item.GetCustomAttribute<NotThis>();
                    bool containThis = tarAttr == null;
                    if (onCmpFinding != null)
                    {
                        try
                        {
                            ft = onCmpFinding(item.Name, ft);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(this.stack(),e);
                        }
                    }
                    IComponent cmp = null;
                    if (isTargetPriority)
                    {
                        cmp = FindFromTarget(ft);
                        if (cmp == null)
                            cmp = entity.FindComponent(ft, containThis);
                    }
                    else
                    {
                        cmp = entity.FindComponent(ft, containThis);
                        if (cmp == null)
                        {
                            cmp = FindFromTarget(ft);
                        }
                    }
                    if (cmp == null)
                    {
                        if (item.GetCustomAttribute<AllowNull>() == null)
                            throw new NullReferenceException($"Inject component <{ft}:{item.Name}> not found anywhere,please add <{ft}> compoennt to leaf or add [AllowNull] attribute to field \nRoute:{this.stack()} ");
                    }
                    item.SetValue(this, cmp);
                }
            }
        }
        IComponent FindFromTarget(Type type)
        {
            var target = entity.FindComponent(typeof(Target)) as Target;
            if (target != null && target.value != null)
            {
                return target.value.Get(type);
            }
            return null;
        }
        public override bool PreDo() => false;
    }
}
