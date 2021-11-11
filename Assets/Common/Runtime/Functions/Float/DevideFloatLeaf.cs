using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class DevideFloat:ATree
	{
        FloatValue left;
        FloatValue right;
        FloatValue output;
        public override void Do()
        {
            output.value = left / right;
            Condition = true;
        }
    }
	public class DevideFloatLeaf: TreeProvider<DevideFloat> { }
}
