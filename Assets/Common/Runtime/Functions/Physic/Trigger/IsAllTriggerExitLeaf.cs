using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IsAllTriggerExit:ATree
	{
        [NotThis] TriggerColiders entered;
        TriggerColiders exit;
		public override void Do()
        {
            Condition = entered.Count == exit.Count;
        }
	}
	public class IsAllTriggerExitLeaf: TreeProvider<IsAllTriggerExit> { }
}
