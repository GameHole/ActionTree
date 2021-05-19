using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class InverseInt:ATree
	{
        IntValue value;
		public override void Do()
        {
            value.value = -value.value;
            Condition = true;
        }
	}
	public class InverseIntLeaf: TreeProvider<InverseInt> { }
}
