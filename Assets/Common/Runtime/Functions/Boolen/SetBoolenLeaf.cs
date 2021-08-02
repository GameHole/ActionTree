using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetBoolen:ATree
	{
        Boolen value;
        Boolen setter;
		public override void Do()
        {
            value.value = setter.value;
            Condition = true;
        }
	}
	public class SetBoolenLeaf: TreeProvider<SetBoolen> { }
}
