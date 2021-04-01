using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RaycastData : IComponent
	{
        public RaycastHit hit;
	}
	public class RaycastPdr: CmpProvider<RaycastData> { }
}
