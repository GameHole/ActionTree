using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TestRA:ATree
	{
        FloatValue value;
        Config<CCC> aaa;
        public override void Do()
        {
            if (aaa.Length > 0)
            {
                Debug.Log($"AA{value.value++} {aaa.Length}");
                Debug.Log($"AA{value.value++} {aaa[0].aaa}");
                Condition = true;
            }
        }
	}
	public class TestRALeaf: TreeProvider<TestRA> { }
}
