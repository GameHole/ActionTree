using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddInt:ATree
	{
        IntValue left;
        IntValue right;
        IntValue output;
		public override void Do()
        {
            output.value = left.value + right.value;
            Condition = true;
        }
	}
	public class AddIntLeaf: TreeProvider<AddInt> { }
}
