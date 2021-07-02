using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
	public sealed class ClearStringValue:ATree
	{
        StringValue value;
		public override void Do()
        {
            value.value = null;
            Condition = true;
        }
	}
	public class ClearStringValueLeaf: TreeProvider<ClearStringValue> { }
}
