using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Hello:ATree
	{
		public override void Do()
        {
            this.Log("Hello World!");
            Condition = true;
        }
	}
	public class HelloLeaf: TreeProvider<Hello> { }
}
