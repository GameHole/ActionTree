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

        public override void Apply()
        {
            reflect();
        }
        void reflect()
        {
            foreach (var item in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var ft = item.FieldType;
                if (ft.IsAbstract | ft.IsValueType) continue;
                var find = item.GetCustomAttribute<Finded>();
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
                        ft = onCmpFinding(item.Name, ft);
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
