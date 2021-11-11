using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class RenderTexProxy : IComponent
	{
        public RenderTexture texture;
	}
    public class RenderTexProxyPdr : CmpProvider<RenderTexProxy> { }
}
