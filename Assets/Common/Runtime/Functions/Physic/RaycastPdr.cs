using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
	public sealed class RaycastData : IComponent
	{
        public Ray ray;
        public float maxDistance;
        public LayerMask layerMask;
        public RaycastHit hit;
	}
	public class RaycastPdr: CmpProvider<RaycastData> { }
}
