using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LogicTestB:ATree
	{
		public override void Do()
        {
            this.Log("TestB");
            Condition = true;
        }
	}
	public class LogicTestBLeaf: TreeProvider<LogicTestB> { }
}
