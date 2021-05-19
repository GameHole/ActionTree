
using UnityEngine;
namespace ActionTree
{
	public sealed class CurveDriver:ATree
	{
        AnimCurve curve;
        [AllowNull]Speed speed;
        public override void Do()
        {
            curve.increase += deltaTime * speed.Speed();
            curve.increase = Mathf.Clamp(curve.increase, curve.increaseRange.x, curve.increaseRange.y);
            curve.output = curve.useCurve ? curve.curve.Evaluate(curve.increase) : curve.increase;
        }
        public override void Clear()
        {
            base.Clear();
            curve.increase = 0;
        }
    }
	public class CurveDriverLeaf: TreeProvider<CurveDriver> { }
}
