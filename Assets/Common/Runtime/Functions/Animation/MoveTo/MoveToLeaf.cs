using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class MoveTo:ATree
	{
        MoveToData data;
        AnimCurve curve;
        Position position;
		public override void Do()
        {
            var dif = data.isFast ? data.dif : data.end - data.start;
            position.value = data.start + dif * curve.output;
        }
	}
	public class MoveToLeaf: TreeProvider<MoveTo> { }
}
