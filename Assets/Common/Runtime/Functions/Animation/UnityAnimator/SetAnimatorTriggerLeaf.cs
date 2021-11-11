using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetAnimatorTrigger:ATree
	{
        AnimatorProxy proxy;
        StringValue name;
		public override void Do()
        {
            proxy.animator.SetTrigger(name);
            Condition = true;
        }
	}
	public class SetAnimatorTriggerLeaf: TreeProvider<SetAnimatorTrigger> { }
}
