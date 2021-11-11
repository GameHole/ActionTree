using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Axis : IComponent
	{
        public int value;
	}
	public class AxisPdr: CmpProvider<Axis> { }
}
