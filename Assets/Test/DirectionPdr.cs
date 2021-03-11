using ActionTree;
using UnityEngine;

namespace Default
{
	[System.Serializable]
	public sealed class Direction:IComponent
    {
        public Vector3 value;
	}
	public class DirectionPdr: CmpProvider<Direction> { }
}
