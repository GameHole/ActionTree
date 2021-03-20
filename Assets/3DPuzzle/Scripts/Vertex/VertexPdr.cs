using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class Vertex : IComponent
	{
        public Vector3Int value;
	}
	public class VertexPdr: CmpProvider<Vertex> { }
}
