using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class FloatValue : IComponent
	{
        public float value;
	}
	public class FloatValuePdr: CmpProvider<FloatValue> { }
}
