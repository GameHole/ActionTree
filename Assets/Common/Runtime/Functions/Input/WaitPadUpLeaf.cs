using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
	public sealed class WaitPadUp:ATree
	{
        PadProxy pad;
		public override void Do()
        {
            Condition = !pad.isDown;
        }
	}
	public class WaitPadUpLeaf: TreeProvider<WaitPadUp> { }
}
