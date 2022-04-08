using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitDrag:ATree
	{
        DragPadProxy proxy;
        Vector3 preposition;
        Vector3Value orgionDirection;
        FloatValue sencity;
        bool isInit;
        bool isdragging;
		public override void Do()
        {
            proxy.direction = Vector3.Lerp(proxy.direction, orgionDirection, deltaTime * sencity);
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
                    //this.Log(proxy.direction);
                    preposition = v.position;
                    isdragging = true;
                }
                proxy.position = v.position;
                //proxy.direction = proxy.position - preposition;
                orgionDirection.value = proxy.position - preposition;
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
