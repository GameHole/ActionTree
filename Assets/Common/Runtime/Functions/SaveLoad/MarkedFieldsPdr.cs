using System;
using System.Collections.Generic;
using System.Reflection;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LoadSave : Attribute { }
    public static class FieldInfoEx
    {
        public static string ToPrefsKey(this FieldInfo field,IComponent component) => $"{component.GetType()}.{field.Name}";
    }
    public sealed class MarkedFields : IComponent
	{
        public class Fields
        {
            public IComponent cmp;
            public List<FieldInfo> fields;
        }
        public List<Fields> fields = new List<Fields>();
	}
	public class MarkedFieldsPdr: CmpProvider<MarkedFields> { }
}
