using ActionTree;
using UnityEngine;

namespace ActionTree
{
	[System.Serializable]
	public sealed class Direction:IComponent
    {
        public Vector3 value;
	}
	public class DirectionPdr: CmpProvider<Direction> { }
}
