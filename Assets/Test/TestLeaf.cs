using ActionTree;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
    public sealed class Test:ATree
	{
		public override void Do()
        {
            Debug.Log("test");
            Debug.Log(this.debug("adsa"));
            //throw new System.NullReferenceException();
            Condition = true;
        }
	}
	public class TestLeaf: TreeProvider<Test> { }
}
