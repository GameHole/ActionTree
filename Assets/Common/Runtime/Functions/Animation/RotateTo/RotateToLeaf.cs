using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotateTo:ATree
	{
        RotateToData rotate;
        Rotation rotation;
        AnimCurve curve;
		public override void Do()
        {
            rotation.value = Quaternion.SlerpUnclamped(rotate.start, rotate.end, curve.output);
        }
	}
	public class RotateToLeaf: TreeProvider<RotateTo> { }
}
