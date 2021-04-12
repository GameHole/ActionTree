using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class UnityAnimatorInOut:ATree
	{
        AnimatorProxy proxy;
        Boolen isIn;
        public override void Do()
        {
            proxy.animator.speed = proxy.speed;
            proxy.animator.SetInteger("state", isIn.value ? 2 : 1);
            Condition = true;
        }
    }
	public class UnityAnimatorInOutLeaf : TreeProvider<UnityAnimatorInOut> { }
}
