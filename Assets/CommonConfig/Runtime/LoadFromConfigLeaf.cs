using System.Reflection;
using System;
using UnityEngine;

namespace ActionTree
{
    public sealed class LoadFromConfig:ATree
	{
        public override void Do()
        {
            foreach (var item in this.FindComponents(typeof(AConfig)))
            {
                InjectData(item as AConfig);
            }
            Condition = true;
        }
        void InjectData(AConfig value)
        {
            string configTxt = value.configTxt;
            string[] items = configTxt.Split('\n');
            var fields = value.classType.GetFields();
            DataDealer[] typeDealers = null;
            for (int i = 0; i < items.Length; i++)
            {
                var values = items[i].Split('/');
                if (i == 0)
                {
                    if(!isTypeVailed(values, fields,out typeDealers))
                    {
                        throw new InvalidCastException($"class type {value.classType}`s fields is not match config data` fields <{items[i]}>");
                    }
                    value.Length = items.Length - 1;
                }
                else
                {
                    var data = Activator.CreateInstance(value.classType) as IConfigValue;
                    for (int index = 0; index < fields.Length; index++)
                    {
                        var field = fields[index];
                        field.SetValue(data, typeDealers[index].GetValue(values[index], field.FieldType));
                    }
                    value.Set(i - 1, data);
                }
            }
            value.configTxt = null;
            value.classType = null;
        }
        bool isTypeVailed(string[] values,FieldInfo[] fields,out DataDealer[] typeStrs)
        {
            typeStrs = default;
            if (values.Length != fields.Length)
                return false;
            typeStrs = new DataDealer[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                string[] info = values[i].Split(' ');
                if (!DataDealer.isMatch(info[0], fields[i].FieldType,out var dealer) || fields[i].Name != info[1].Trim())
                {
                    return false;
                }
                typeStrs[i] = dealer;
            }
            return true;
        }
	}
	public class LoadFromConfigLeaf: TreeProvider<LoadFromConfig> { }
}
