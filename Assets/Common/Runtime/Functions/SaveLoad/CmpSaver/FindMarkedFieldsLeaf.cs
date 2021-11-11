using ActionTree;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace ActionTree
{
	public sealed class FindMarkedFields:ATree
	{
        MarkedFields fields;
        public override void Do()
        {
            foreach (var type in entity.CmpTypes)
            {
                var cmpLoad = type.GetCustomAttribute<LoadSave>();
                List<FieldInfo> list = new List<FieldInfo>();
                foreach (var field in type.GetFields())
                {
                    var load = field.GetCustomAttribute<LoadSave>();
                    if (cmpLoad != null || load != null)
                    {
                        list.Add(field);
                    }
                }
                if (list.Count > 0)
                {
                    fields.fields.Add(new MarkedFields.Fields() { cmp = entity.Get(type), fields = list });
                }
            }
            Condition = true;
        }
	}
	public class FindMarkedFieldsLeaf: TreeProvider<FindMarkedFields> { }
}
