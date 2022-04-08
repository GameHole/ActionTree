using ActionTree;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
    [MainThread]
	public sealed class WaitDragDrivedByInput:ATree
	{
        DragPadProxy proxy;
        Vector3 prePosition;
        //bool isInit;
        bool isDown;
        public override void Do()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(proxy.pad.GetComponent<RectTransform>(), Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    prePosition = Input.mousePosition;
                    isDown = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDown = false;
                proxy.direction = Vector3.zero;
            }
            if (isDown)
            {
                proxy.direction = Input.mousePosition - prePosition;
                prePosition = Input.mousePosition;
            }
            Condition = isDown;
            //if (isInit) return;
            //isInit = true;
            //proxy.pad.onPointerDown += (PointerEventData data) =>
            //{
            //    prePosition = Input.mousePosition;
            //    isDown = true;
            //};
            //proxy.pad.onPointerUp += (PointerEventData data) =>
            //{
            //    isDown = false;
            //};
            //Condition = true;
        }
	}
	public class WaitDragDrivedByInputLeaf: TreeProvider<WaitDragDrivedByInput> { }
}
