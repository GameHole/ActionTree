using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitEnable:ATree
	{
        Boolen isEnable;
        Enable enable;
		public override void Do()
        {
            Condition = (!isEnable.Value()) ^ enable.value;
        }
	}
	public class WaitEnableLeaf: TreeProvider<WaitEnable> { }
}
