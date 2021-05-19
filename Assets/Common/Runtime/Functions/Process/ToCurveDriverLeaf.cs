using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
	public sealed class ToCurveDriver:ATree
	{
        AnimCurve curve;
        Process process;
		public override void Do()
        {
            if (curve.increase < process.value)
                curve.increase = process.value;
            Condition = true;
        }
	}
	public class ToCurveDriverLeaf: TreeProvider<ToCurveDriver> { }
}
