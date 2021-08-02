using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class FloatMultiplyInt:ATree
	{
        FloatValue output;
        FloatValue valueA;
        IntValue valueB;
		public override void Do()
        {
            output.value = valueA * valueB;
            Condition = true;
        }
	}
	public class FloatMultiplyIntLeaf: TreeProvider<FloatMultiplyInt> { }
}
