using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class StringValue : IComponent
	{
        public string value;
        public static implicit operator string(StringValue value)
        {
            return value.value;
        }
    }
	public class StringValuePdr: CmpProvider<StringValue> { }
}
