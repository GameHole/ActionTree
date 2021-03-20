using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class WaitDeactive:ATree
	{
        Active active;
		public override void Do()
        {
            Condition = !active.value;
        }
	}
	public class WaitDeactiveLeaf : TreeProvider<WaitDeactive> { }
}
