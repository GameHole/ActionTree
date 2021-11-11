using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public class Value<T> : IComponent
	{
        public T value;
        public static implicit operator T(Value<T> value)
        {
            return value.value;
        }
	}
}
