using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class QuaternionMulVec3:ATree
	{
        QuaternionValue quaternion;
        Vector3Value vector;
        Vector3Value output;
        public override void Do()
        {
            output.value = quaternion.value * vector.value;
            Condition = true;
        }
	}
	public class QuaternionMulVec3Leaf: TreeProvider<QuaternionMulVec3> { }
}
