using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TestRB:ATree
	{
        FloatValue value;
		public override void Do()
        {
            Debug.Log("B" + value.value++);
            Condition = true;
        }
	}
	public class TestRBLeaf : TreeProvider<TestRB> { }
}
