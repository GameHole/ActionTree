using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetTargetEnable:ATree
	{
        Target target;
        Boolen enable;
		public override void Do()
        {
            target.Get<Enable>().value = enable.Value();
            Condition = true;
        }
	}
	public class SetTargetEnableLeaf: TreeProvider<SetTargetEnable> { }
}
