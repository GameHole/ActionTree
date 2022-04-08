using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class MulQuaternion:ATree
	{
        QuaternionValue left;
        QuaternionValue right;
        QuaternionValue output;
		public override void Do()
        {
            output.value = left.value * right.value;
            Condition = true;
        }
	}
	public class MulQuaternionLeaf: TreeProvider<MulQuaternion> { }
}
