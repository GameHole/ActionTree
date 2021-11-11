using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitPadPress:ATree
	{
        PadProxy proxy;
		public override void Do()
        {
            proxy.Init();
            Condition = proxy.isDown;
        }
	}
	public class WaitPadPressLeaf : TreeProvider<WaitPadPress> { }
}
