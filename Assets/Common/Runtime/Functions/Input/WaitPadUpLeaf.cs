using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitPadUp:ATree
	{
        PadProxy pad;
        public override void Do()
        {
            pad.Init();
            Condition = !pad.isDown;
        }
	}
	public class WaitPadUpLeaf: TreeProvider<WaitPadUp> { }
}
