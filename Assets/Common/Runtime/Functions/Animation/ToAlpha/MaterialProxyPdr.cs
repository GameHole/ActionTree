using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace ActionTree
{
    [System.Serializable]
    public sealed class MaterialProxy : IComponent
	{
        public Material material;
	}
	public class MaterialProxyPdr: CmpProvider<MaterialProxy>
    {
        public Renderer _renderer;
        public override IComponent GetValue()
        {
            if (_renderer != null)
                value.material = _renderer.material;
            return base.GetValue();
        }
    }
}
