using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class TestUnityCmp:ATree
	{
        TestUnityComponent component;
		public override void Do()
        {
            this.Log(component.text.text);
            Condition = true;
        }
	}
	public class TestUnityCmpLeaf: TreeProvider<TestUnityCmp> { }
}
