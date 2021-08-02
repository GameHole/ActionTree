using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class MultiplyFloat:ATree
	{
        FloatValue output;
        FloatValue valueA;
        FloatValue valueB;
        public override void Do()
        {
            output.value = valueA * valueB;
            Condition = true;
        }
	}
	public class MultiplyFloatLeaf: TreeProvider<MultiplyFloat> { }
}
