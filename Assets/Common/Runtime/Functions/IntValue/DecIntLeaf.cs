using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class DecInt:ATree
	{
        IntValue value;
        public override void Do()
        {
            value.value--;
            Condition = true;
        }
    }
	public class DecIntLeaf: TreeProvider<DecInt> { }
}
