using ActionTree;
using System;
using System.Reflection;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
	public sealed class LoadWhenMarked:ATree
	{
        MarkedFields fields;
        DataSaver data;
        public override void Do()
        {
            var fieldlist = fields.fields;
            for (int i = 0; i < fieldlist.Count; i++)
            {
                var fl = fieldlist[i].fields;
                var cmp = fieldlist[i].cmp;
                for (int j = 0; j < fl.Count; j++)
                {
                    var field = fl[j];
                    field.SetValue(cmp, GetValue(field.ToPrefsKey(cmp), field.FieldType));
                }
            }
            Condition = true;
        }
        object GetValue(string key,Type fieldType)
        {
            if (fieldType == typeof(int))
                return data.Get<int>(key,0);
            if (fieldType == typeof(float))
                return data.Get<float>(key, 0);
            throw new NotSupportedException("Loaded type just support 'int','float'");
        }
	}
	public class LoadWhenMarkedLeaf: TreeProvider<LoadWhenMarked> { }
}
