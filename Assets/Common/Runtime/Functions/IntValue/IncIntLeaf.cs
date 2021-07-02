using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IncInt:ATree
	{
        IntValue value;
		public override void Do()
        {
            value.value++;
            Condition = true;
        }
	}
	public class IncIntLeaf: TreeProvider<IncInt> { }
}
