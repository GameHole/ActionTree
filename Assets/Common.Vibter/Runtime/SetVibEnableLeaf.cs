using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
	public sealed class SetVibEnable:ATree
	{
        Enable enable;
		public override void Do()
        {
            Vibrator.canRun = enable.value;
            Condition = true;
        }
	}
	public class SetVibEnableLeaf: TreeProvider<SetVibEnable> { }
}
