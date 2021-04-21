using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class ThisIsTarget:ATree
	{
        Target target;
        public override void Do()
        {
            target.value = entity;
            Condition = true;
        }
	}
	public class ThisIsTargetLeaf: TreeProvider<ThisIsTarget> { }
}
