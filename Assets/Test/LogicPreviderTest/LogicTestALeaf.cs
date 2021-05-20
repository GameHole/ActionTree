using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LogicTestA:ATree
	{
		public override void Do()
        {
            this.Log("TestA");
            Condition = true;
        }
	}
	public class LogicTestALeaf: TreeProvider<LogicTestA> { }
}
