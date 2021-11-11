using ActionTree;
using System;
using System.Reflection;
using UnityEngine;
namespace ActionTree
{
	public sealed class SaveWhenMarked:ATree
	{
        MarkedFields fields;
        DataSaver saver;
        public override void Do()
        {
            var fieldlist = fields.fields;
            for (int i = 0; i < fieldlist.Count; i++)
            {
                var fl = fieldlist[i].fields;
                var cmp = fieldlist[i].cmp;
                for (int j = 0; j < fl.Count; j++)
                {
                    SetValue(fl[j], cmp);
                }
            }
            Condition = true;
        }
        void SetValue(FieldInfo field, IComponent component)
        {
            string key = field.ToPrefsKey(component);
            var fieldType = field.FieldType;
            var value = field.GetValue(component);
            if (fieldType == typeof(int))
                saver.Set(key, (int)value);
            else if (fieldType == typeof(float))
                saver.Set(key, (float)value);
            else
                throw new NotSupportedException("Saveded type just support 'int','float'");
        }
    }
	public class SaveWhenMarkedLeaf: TreeProvider<SaveWhenMarked> { }
}
