using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
	[System.Serializable]
	public sealed class PadProxy : IComponent
	{
        public bool isDown => data != null;
        [HideInInspector]public PointerEventData data;
        //public bool isIn;
        public Pad pad;
	}
	public class PadProxyPdr: CmpProvider<PadProxy>
    {
        public override IComponent GetValue()
        {
            value.pad.onDown += (v) =>
            {
                value.data = v;
            };
            value.pad.onUp += (v) =>
            {
                value.data = null;
            };
            //value.pad.onEnter += (v) =>
            //{
            //    value.isIn = true;
            //};
            //value.pad.onExit += (v) =>
            //{
            //    value.isIn = false;
            //};
            return base.GetValue();
        }
    }
}
