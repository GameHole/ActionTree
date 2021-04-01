using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class Vertex : IComponent
	{
        public Vector3Int value;
	}
	public class VertexPdr: CmpProvider<Vertex> { }
}
