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
            rotation.value = Quaternion.Euler((1 - curve.output) * rotate.startEuler + rotate.endEuler * curve.output);//Quaternion.Slerp(rotate.start, rotate.end, curve.output);
            //this.Log($"{rotate.start} {rotate.end}");
        }
	}
	public class RotateToLeaf: TreeProvider<RotateTo> { }
}
