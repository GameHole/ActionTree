using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetInt:ATree
	{
        IntValue left;
        IntValue right;
		public override void Do()
        {
            left.value = right.value;
            Condition = true;
        }
	}
	public class SetIntLeaf: TreeProvider<SetInt> { }
}
