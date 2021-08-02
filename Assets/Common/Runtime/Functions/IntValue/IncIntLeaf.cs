using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IncInt:ATree
	{
        IntValue value;
		public override void Do()
        {
            //this.Log("inc");
            value.value++;
            Condition = true;
        }
	}
	public class IncIntLeaf: TreeProvider<IncInt> { }
}
