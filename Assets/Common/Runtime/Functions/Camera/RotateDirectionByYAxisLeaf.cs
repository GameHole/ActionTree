using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotateDirectionByYAxis:ATree
	{
        Direction direction;
        EulerAngle angle;
		public override void Do()
        {
            direction.value = Quaternion.AngleAxis(angle.value.y, Vector3.up) * direction.value;
            Condition = true;
        }
	}
	public class RotateDirectionByYAxisLeaf: TreeProvider<RotateDirectionByYAxis> { }
}
