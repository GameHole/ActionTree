using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
	public sealed class WaitAnim:ATree
	{
        AnimatorProxy proxy;
        Boolen isOut;
        public override void Do()
        {
            proxy.animator.speed = proxy.speed;
            proxy.animator.SetInteger("state", isOut.value ? 1 : 2);
            Condition = true;
        }
    }
	public class WaitAnimLeaf: TreeProvider<WaitAnim> { }
}
