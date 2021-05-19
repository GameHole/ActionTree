using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class IntValue : IComponent
	{
        public int value;
        public static implicit operator int(IntValue value)
        {
            return value.value;
        }
	}
	public class IntValuePdr: CmpProvider<IntValue> { }
}
