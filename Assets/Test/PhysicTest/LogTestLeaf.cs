using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LogTest:ATree
	{
        Collisions coliders;
		public override void Do()
        {
            for (int i = 0; i < coliders.collisions.Count; i++)
            {
                foreach (var item in coliders.collisions[i].contacts)
                {
                    Debug.Log(this.debug(item.normal));
                }
            }
            throw new System.NullReferenceException();
            Condition = true;
        }
	}
	public class LogTestLeaf: TreeProvider<LogTest> { }
}
