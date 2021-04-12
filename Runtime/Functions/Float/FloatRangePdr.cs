using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class FloatRange : IComponent
	{
        public float min;
        public float max;
	}
	public class FloatRangePdr: CmpProvider<FloatRange> { }
}
