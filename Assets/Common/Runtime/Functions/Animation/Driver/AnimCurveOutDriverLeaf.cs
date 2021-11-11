using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AnimCurveOutDriver:ATree
	{
        AnimCurveProxy curve;
        AnimDriveData driveData;
        AnimDriveOutPut outPut;
        public override void Do()
        {
            outPut.value = curve.curve.Evaluate(driveData.value);
            Condition = true;
        }
	}
	public class AnimCurveOutDriverLeaf: TreeProvider<AnimCurveOutDriver> { }
}
