using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Axis3 : IComponent
	{
        public Vector3 value = Vector3.up;
	}
	public class Axis3Pdr: CmpProvider<Axis3> { }
}
