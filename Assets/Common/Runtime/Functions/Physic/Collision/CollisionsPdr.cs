using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class Collisions : IComponent
	{
        public List<Collision> collisions = new List<Collision>();
	}
	public class CollisionsPdr: CmpProvider<Collisions> { }
}
