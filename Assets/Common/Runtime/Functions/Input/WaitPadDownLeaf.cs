using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitPadDown:ATree
	{
        PadProxy proxy;
		public override void Do()
        {
            Condition = proxy.isDown;
        }
	}
	public class WaitPadDownLeaf: TreeProvider<WaitPadDown> { }
}
