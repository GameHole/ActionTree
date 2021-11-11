using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class Vector2Value : IComponent
	{
        public Vector2 value;
	}
	public class Vector2ValuePdr: CmpProvider<Vector2Value> { }
}
