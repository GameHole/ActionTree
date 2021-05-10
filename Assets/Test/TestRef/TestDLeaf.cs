using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class TestD:ATree
	{
        [Finded] Temm aaa;
		public override void Do()
        {
            Debug.Log(this.debug( aaa));
            Debug.Log(this.debug("over"));
            Condition = true;
        }
	}
	public class TestDLeaf: TreeProvider<TestD> { }
}
