using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AngleToQuaternion:ATree
	{
        QuaternionValue quaternion;
        FloatValue angle;
        Vector3Value axis;
		public override void Do()
        {
            quaternion.value = Quaternion.AngleAxis(angle, axis);
            Condition = true;
        }
	}
	public class AngleToQuaternionLeaf: TreeProvider<AngleToQuaternion> { }
}
