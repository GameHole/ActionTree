using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LogTest:ATree
	{
        TriggerColiders coliders;
		public override void Do()
        {
            //for (int i = 0; i < coliders.Count; i++)
            //{
            //    //Debug.Log(coliders[i]);
            //}
           
            Condition = true;
        }
	}
	public class LogTestLeaf: TreeProvider<LogTest> { }
}
