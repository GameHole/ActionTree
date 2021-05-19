using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class TestLog:ATree
	{
		public override void Do()
        {
            this.Log("aaa");
            Condition = true;
        }
	}
	public class TestLogLeaf: TreeProvider<TestLog> { }
}
