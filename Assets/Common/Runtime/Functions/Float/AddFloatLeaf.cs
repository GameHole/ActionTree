using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddFloat:ATree
	{
        FloatValue left;
        FloatValue right;
        FloatValue output;
		public override void Do()
        {
            output.value = left + right;
            Condition = true;
        }
	}
	public class AddFloatLeaf: TreeProvider<AddFloat> { }
}
