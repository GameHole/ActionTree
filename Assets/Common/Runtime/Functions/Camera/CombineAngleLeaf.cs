using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class CombineAngle:ATree
	{
        FloatValue angle;
        EulerAngle rotation;
        Axis axis;
		public override void Do()
        {
            rotation.value[axis.value] = angle.value;
            Condition = true;
        }
    }
	public class CombineAngleLeaf: TreeProvider<CombineAngle> { }
}
