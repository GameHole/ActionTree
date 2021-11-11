using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class StateToVib:ATree
	{
        IntValue state;
		public override void Do()
        {
            Vibrator.canRun = state == 0;
            Condition = true;
        }
	}
	public class StateToVibLeaf: TreeProvider<StateToVib> { }
}
