using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class QuaternionSLerp:ATree
	{
        QuaternionValue left;
        QuaternionValue right;
        QuaternionValue output;
        FloatValue speed;
        public override void Do()
        {
            output.value = Quaternion.Slerp(left, right, speed * deltaTime);
            Condition = true;
        }
	}
	public class QuaternionSLerpLeaf: TreeProvider<QuaternionSLerp> { }
}
