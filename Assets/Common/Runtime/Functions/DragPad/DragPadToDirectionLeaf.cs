using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class DragPadToDirection:ATree
	{
        Direction direction;
        DragPadProxy proxy;
        public override void Do()
        {
            Vector3 dir = proxy.direction;
            direction.value = new Vector3(dir.y, 0, -dir.x);
            Condition = true;
        }
	}
	public class DragPadToDirectionLeaf: TreeProvider<DragPadToDirection> { }
}
