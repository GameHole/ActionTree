using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IntProcess:ATree
	{
        IntValue min;
        IntValue max;
        FloatValue process;
		public override void Do()
        {
            process.value = (float)min / max;
            Condition = true;
        }
	}
	public class IntProcessLeaf: TreeProvider<IntProcess> { }
}
