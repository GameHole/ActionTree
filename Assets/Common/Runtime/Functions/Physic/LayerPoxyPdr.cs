using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class LayerPoxy : IComponent
	{
        public LayerMask value;
	}
	public class LayerPoxyPdr: CmpProvider<LayerPoxy> { }
}
