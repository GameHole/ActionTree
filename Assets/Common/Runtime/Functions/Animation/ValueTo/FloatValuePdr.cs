using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class FloatValue : IComponent
	{
        public float value;
        public static implicit operator float(FloatValue value)
        {
            return value.value;
        }
	}
    public static class FloatValueEx
    {
        public static float zero(this FloatValue value)
        {
            if (value == null)
                return 0;
            return value.value;
        }
    }

    public class FloatValuePdr: CmpProvider<FloatValue> { }
}
