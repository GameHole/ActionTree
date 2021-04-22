using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Axis : IComponent
	{
        public Vector3 value = Vector3.up;
	}
	public class AxisPdr: CmpProvider<Axis> { }
}
