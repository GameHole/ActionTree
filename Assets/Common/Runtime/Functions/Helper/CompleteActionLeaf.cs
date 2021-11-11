using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class CompleteAction:ATree
	{
		public override void Do()
        {
            Condition = true;   
        }
	}
	public class CompleteActionLeaf: TreeProvider<CompleteAction> { }
}
