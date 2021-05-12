using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TargetIsSelf:ATree
	{
        Target target;
		public override void Do()
        {
            target.value = entity;
            Condition = true;
        }
	}
	public class TargetIsSelfLeaf: TreeProvider<TargetIsSelf> { }
}
