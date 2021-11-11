using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotateTo:ATree
	{
        RotateToData rotate;
        Rotation rotation;
        FloatValue draveData;
		public override void Do()
        {
            rotation.value = Quaternion.Euler((1 - draveData) * rotate.startEuler + rotate.endEuler * draveData);//Quaternion.Slerp(rotate.start, rotate.end, curve.output);
            //this.Log($"{rotate.start} {rotate.end}");
        }
	}
	public class RotateToLeaf: TreeProvider<RotateTo> { }
}
