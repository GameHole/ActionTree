using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
	public static class ObjectEx
	{
        public static Dictionary<string,T> GetNameMap<T>(this T[] array)where T : Object
        {
            Dictionary<string, T> catches = new Dictionary<string, T>();
            foreach (var item in array)
            {
                catches.Add(item.name, item);
            }
            return catches;
        }
        public static Dictionary<string, T> GetNameMap<T>(this Array<T> array) where T : Object
        {
            Dictionary<string, T> catches = new Dictionary<string, T>();
            foreach (var item in array)
            {
                catches.Add(item.name, item);
            }
            return catches;
        }
    }
}
