using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SubFloat:ATree
	{
        FloatValue left;
        FloatValue right;
        FloatValue output;
        public override void Do()
        {
            output.value = left - right;
            Condition = true;
        }
    }
	public class SubFloatLeaf: TreeProvider<SubFloat> { }
}
