using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class ThisIsTarget:ATree
	{
        Target target;
        public override void Do()
        {
            target.value = Entity;
            Condition = true;
        }
	}
	public class ThisIsTargetLeaf: TreeProvider<ThisIsTarget> { }
}
