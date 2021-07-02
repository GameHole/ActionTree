using System.Collections.Generic;
using ActionTree;
using UnityEngine.UI;
namespace ActionTree
{
	[System.Serializable]
	public sealed class GraphicProxy : IComponent
	{
        public Graphic value;
	}
	public class GraphicProxyPdr: CmpProvider<GraphicProxy> { }
}
