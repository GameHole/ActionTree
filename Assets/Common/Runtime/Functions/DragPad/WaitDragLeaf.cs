using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitDrag:ATree
	{
        DragPadProxy proxy;
        Vector3 preposition;
        bool isInit;
        bool isdragging;
		public override void Do()
        {
            if (isInit) return;
            isInit = true;
            //proxy.pad.onBeginDrag += (v) =>
            //{
            //    preposition = v.position;
            //};
            proxy.pad.onDrag += (v) =>
            {
                if (!isdragging)
                {
                    preposition = v.position;
                    isdragging = true;
                }
                proxy.position = v.position;
                proxy.direction = proxy.position - preposition;
                preposition = proxy.position;
                Condition = true;
            };
            proxy.pad.onEndDrag += (v) =>
            {
                isdragging = Condition = false;
            };
            //Condition = proxy.isDrag;
        }
	}
	public class WaitDragLeaf: TreeProvider<WaitDrag> { }
}
