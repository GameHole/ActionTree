﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActionTree
{
    public abstract class ATree : Tree
    {
        public static float deltaTime { get; internal set; }
        public Driver driver;
        internal List<FieldInfo> needFindInfo;
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
                    var cmp = entity.FindComponent(ft);
                    //var tarAttr = item.GetCustomAttribute<TargetAttribute>();
                    if (cmp == null/*|| tarAttr != null*/)
                    {
                        cmp = FindFromTarget(ft);
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
