using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class ClearDragPadDirection:ATree
	{
        DragPadProxy proxy;
		public override void Do()
        {
            proxy.direction = Vector3.zero;
            Condition = true;
        }
	}
	public class ClearDragPadDirectionLeaf : TreeProvider<ClearDragPadDirection> { }
}
