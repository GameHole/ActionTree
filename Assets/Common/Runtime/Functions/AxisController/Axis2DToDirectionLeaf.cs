using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Axis2DToDirection:ATree
	{
        Vector2Value axis;
        Direction direction;
		public override void Do()
        {
            Vector3 dir = direction.value;
            dir.x = axis.value.x;
            dir.z = axis.value.y;
            direction.value = dir;
            Condition = true;
        }
	}
	public class Axis2DToDirectionLeaf: TreeProvider<Axis2DToDirection> { }
}
