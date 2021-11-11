using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class EulerAngleToRotation:ATree
	{
        Vector3Value value;
        Rotation data;
		public override void Do()
        {
            data.value = Quaternion.Euler(value);
            Condition = true;
        }
	}
	public class EulerAngleToRotationLeaf: TreeProvider<EulerAngleToRotation> { }
}
