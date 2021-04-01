using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotateVertex : IComponent
	{
        public Vector3Int value;
	}
	public class RotateVertexPdr: CmpProvider<RotateVertex> { }
}
