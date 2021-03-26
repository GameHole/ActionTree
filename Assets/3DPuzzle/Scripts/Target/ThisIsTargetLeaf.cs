using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class ThisIsTarget:ATree
	{
        Target target;
        public override void Do()
        {
            target.value = (ETree)Parent;
            Condition = true;
        }
	}
	public class ThisIsTargetLeaf: TreeProvider<ThisIsTarget> { }
}
