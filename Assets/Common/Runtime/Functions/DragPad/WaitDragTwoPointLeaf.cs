using ActionTree;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ActionTree
{
    public sealed class WaitDragTwoPoint : ATree
    {
        DragPadProxy proxy;
        DragTwoPointDir dir;
        bool isInited;
        List<PointerEventData> pointers = new List<PointerEventData>();
        float pv;
        int idx = 0;
        public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.pad.onPointerDown += (PointerEventData v) =>
            {
                pointers.Add(v);
                if (pointers.Count >= 2)
                {
                    pv = (pointers[0].position - pointers[1].position).magnitude;
                }
                //this.Log($"add:::{v.pointerId}");
            };
            proxy.pad.onDrag += (PointerEventData v) =>
            {
                idx++;
                if (idx < 2) return;
                idx = 0;
                //this.Log($"count::{pointers.Count}");
                if (pointers.Count >= 2)
                {
                    Vector3 dx0 = pointers[0].position;
                    Vector3 dx1 = pointers[1].position;
                    float dx = (dx0 - dx1).magnitude;
                    dir.value = dx - pv;
                    //this.Log($"dx::{dir.value },x::{dx} last::{pv}");
                    pv = dx;
                    Condition = true;
                }
            };
            proxy.pad.onPointerUp += (PointerEventData v) =>
            {
                //this.Log($"remove:::{v.pointerId}");
                pointers.Remove(v);
                Condition = false;
            };
        }
    }
	public class WaitDragTwoPointLeaf: TreeProvider<WaitDragTwoPoint> { }
}
