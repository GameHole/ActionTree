using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class UseTestA:ATree
	{
        IntValue testA;
		public override void Do()
        {
            testA.value++;
            Condition = true;
        }
	}
	public class UseTestALeaf: TreeProvider<UseTestA> { }
}
