using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetEnable:ATree
	{
        Boolen setter;
        Enable enable;
		public override void Do()
        {
            enable.value = setter.Value();
            Condition = true;
        }
	}
	public class SetEnableLeaf: TreeProvider<SetEnable> { }
}
