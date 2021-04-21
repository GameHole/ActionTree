using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActionTree
{
    public abstract class ATree : Tree
    {
        public static float deltaTime { get; internal set; }
        public Driver driver;
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
                if (ft.IsAbstract | ft.IsInterface | ft.IsValueType) continue;
                if (ft.IsArray)
                {
                    var type = ft.GetElementType();
                    var list = entity.FindAll(type);
                    var array = Array.CreateInstance(type, list.Count);
                    for (int i = 0; i < list.Count; i++)
                    {
                        array.SetValue(list[i], i);
                    }
                    //var listType = typeof(List<>).MakeGenericType(type);
                    //var list = Activator.CreateInstance(listType);
                    //var add = listType.GetMethod("Add");
                    //var toarray = listType.GetMethod("ToArray");
                    //var parnet = entity;
                    //while (parnet != null)
                    //{
                    //    //UnityEngine.Debug.Log($"finding {item.FieldType} ::{parnet}");
                    //    var cmp = parnet.Get(type);
                    //    if (cmp != null)
                    //        add.Invoke(list, new object[] { cmp });
                    //    parnet = parnet.parent;
                    //}
                    item.SetValue(this, array);
                }
                else
                {
                    //UnityEngine.Debug.Log($"{this} e {Entity}");
                    //IComponent cmp = Entity.Get(ft);
                    ////if (item.GetCustomAttribute<ParentAttribute>() == null)
                    ////{
                    ////    cmp = FindType(ft);
                    ////}
                    ////else
                    ////{
                    ////    UnityEngine.Debug.Log("find from parnet");
                    ////}
                    //var parnet = Entity.parent;
                    //while (cmp == null && parnet != null)
                    //{
                    //    //UnityEngine.Debug.Log($"finding {item.FieldType} ::{parnet}");
                    //    cmp = parnet.Get(ft);
                    //    parnet = parnet.parent;
                    //}
                    //if (cmp == null)
                    //    throw new System.NullReferenceException($"this::{this} field::{item.Name},type::{ft} is not found");
                    //UnityEngine.Debug.Log($"{item.Name} ::{cmp}");
                    item.SetValue(this, entity.FindComponent(ft));
                }
            }
        }
        public override bool PreDo() => false;
    }
}
