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
        bool isInited;
        public void Init()
        {
            if (pad == null || isInited) return;
            isInited = true;
            pad.onDown += (v) =>
            {
                isDown = true;
            };
            pad.onUp += (v) =>
            {
                isDown = false;
            };
        }
	}
	public class PadProxyPdr: CmpProvider<PadProxy>
    {
        public override IComponent GetValue()
        {
            value.Init();
            //value.pad.onDown += (v) =>
            //{
            //    value.isDown = true;
            //};
            //value.pad.onUp += (v) =>
            //{
            //    value.isDown = false;
            //};
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
