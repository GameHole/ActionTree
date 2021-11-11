using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
	public static class RefinterEx
	{
        public static T GetShared<T>() where T : IInterface
        {
            Refinter.Reflection.Interfaces.TryGetValue(typeof(T), out var inter);
            return (T)inter;
        }
        public static void SetShared(System.Type type, IInterface v)
        {
            if (Refinter.Reflection.Interfaces.ContainsKey(type))
                Refinter.Reflection.Interfaces[type] = v;
        }
	}
}
