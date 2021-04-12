using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitEnable:ATree
	{
        Boolen boolen;
        Enable enable;
		public override void Do()
        {
            Condition = (!boolen.Value()) ^ enable.value;
        }
	}
	public class WaitEnableLeaf: TreeProvider<WaitEnable> { }
}
