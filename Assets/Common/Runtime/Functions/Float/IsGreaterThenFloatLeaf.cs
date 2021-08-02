using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IsGreaterThenFloat:ATree
	{
        FloatValue value;
        FloatValue compared;
        [AllowNull] Boolen isInverse;
		public override void Do()
        {
            Condition = isInverse.Value(false) ^ value >= compared;
        }
	}
	public class IsGreaterThenFloatLeaf: TreeProvider<IsGreaterThenFloat> { }
}
