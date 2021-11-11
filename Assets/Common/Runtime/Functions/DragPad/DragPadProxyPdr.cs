using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class DragPadProxy : IComponent
	{
        //[HideInInspector]public bool isDrag;
        [HideInInspector] public Vector3 position;
        [HideInInspector] public Vector3 direction;
        public DragPad pad;
	}
	public class DragPadProxyPdr : CmpProvider<DragPadProxy>
    {
        public override IComponent GetValue()
        {
            //value.pad.onEntry += (v) =>
            //{
            //    value.preposition = v;
            //};
            //value.pad.onDrag += (v) =>
            //{
            //    value.isDrag = true;
            //    value.position = v;
            //    value.direction = value.position - value.preposition;
            //    value.preposition = value.position;
            //};
            //value.pad.onExit += (v) =>
            //{
            //    value.isDrag = false;
            //};
            return base.GetValue();
        }
    }
}
