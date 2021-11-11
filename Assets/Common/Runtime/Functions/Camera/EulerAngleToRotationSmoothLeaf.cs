using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class EulerAngleToRotationSmooth:ATree
	{
        EulerAngle eulerAngle;
        Rotation rotation;
        FloatValue smoothRate;
		public override void Do()
        {
            rotation.value = Quaternion.Slerp(rotation.value, Quaternion.Euler(eulerAngle.value), deltaTime * smoothRate);
            Condition = true;
        }
	}
	public class EulerAngleToRotationSmoothLeaf : TreeProvider<EulerAngleToRotationSmooth> { }
}
