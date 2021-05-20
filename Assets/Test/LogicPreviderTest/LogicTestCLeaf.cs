using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LogicTestC:ATree
	{
		public override void Do()
        {
            this.Log("TestC");
            Condition = true;
        }
	}
	public class LogicTestCLeaf: TreeProvider<LogicTestC> { }
}
