using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class PadProxy : IComponent
	{
        public bool isDown;
        public Pad pad;
	}
	public class PadProxyPdr: CmpProvider<PadProxy>
    {
        public override IComponent GetValue()
        {
            value.pad.onDown += (v) =>
            {
                value.isDown = true;
            };
            value.pad.onUp += (v) =>
            {
                value.isDown = false;
            };
            return base.GetValue();
        }
    }
}
