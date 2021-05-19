using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
	[System.Serializable]
	public sealed class PadProxy : IComponent
	{
        public bool isDown;
        //[HideInInspector]public PointerEventData data;
        //public bool isIn;
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
