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
            rotation.value = Quaternion.Lerp(rotate.start, rotate.end, curve.output);
        }
	}
	public class RotateToLeaf: TreeProvider<RotateTo> { }
}
