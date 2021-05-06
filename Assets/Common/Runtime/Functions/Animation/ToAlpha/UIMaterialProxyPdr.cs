using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace ActionTree
{
    public class UIMaterialProxyPdr : CmpProvider<MaterialProxy>
    {
        public Graphic _renderer;
        public override IComponent GetValue()
        {
            value.material = _renderer.material;
            return base.GetValue();
        }
    }
}
