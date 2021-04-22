using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AngleToRotation:ATree
	{
        FloatValue angle;
        Axis axis;
        Rotation rotation;
		public override void Do()
        {
            angle.value %= 360;
            rotation.value = Quaternion.AngleAxis(angle.value, axis.value);
        }
	}
	public class AngleToRotationLeaf: TreeProvider<AngleToRotation> { }
}
