using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TargetIsParent:ATree
	{
        Target target;
		public override void Do()
        {
            target.value = entity.parent;
            Condition = true;
        }
	}
	public class TargetIsParentLeaf: TreeProvider<TargetIsParent> { }
}
