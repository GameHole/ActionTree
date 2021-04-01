using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class WaitTarget:ATree
	{
        Target target;
		public override void Do()
        {
            Condition = target.value != null;
            //Debug.Log(target.value);
        }
	}
	public class WaitTargetLeaf: TreeProvider<WaitTarget> { }
}
