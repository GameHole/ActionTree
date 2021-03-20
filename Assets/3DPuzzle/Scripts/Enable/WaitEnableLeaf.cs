using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class WaitEnable:ATree
	{
        public bool isInverse;
        Enable enable;
		public override void Do()
        {
            Condition = isInverse ^ enable.value;
        }
	}
	public class WaitEnableLeaf: TreeProvider<WaitEnable> { }
}
