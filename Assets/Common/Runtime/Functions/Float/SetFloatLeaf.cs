using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetFloat:ATree
	{
        FloatValue left;
        FloatValue right;
		public override void Do()
        {
            left.value = right.value;
            Condition = true;
        }
	}
	public class SetFloatLeaf: TreeProvider<SetFloat> { }
}
