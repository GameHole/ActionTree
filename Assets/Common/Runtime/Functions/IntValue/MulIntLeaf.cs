using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class MulInt:ATree
	{
        IntValue left;
        IntValue right;
        IntValue output;
		public override void Do()
        {
            output.value = left * right;
            Condition = true;
        }
	}
	public class MulIntLeaf: TreeProvider<MulInt> { }
}
