using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitCurve:ATree
	{
        AnimCurve curve;
        Speed speed;
		public override void Do()
        {
            Condition = speed.Speed() >= 0 ? curve.increase >= curve.increaseRange.y : curve.increase <= curve.increaseRange.x;
        }
	}
	public class WaitCurveLeaf: TreeProvider<WaitCurve> { }
}
