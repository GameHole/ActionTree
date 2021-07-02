using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitProcess:ATree
	{
        Process process;
        FloatValue value;
        [AllowNull]Boolen inverse;
		public override void Do()
        {
            //Debug.Log(this.debug(process.value));
            Condition = inverse.Value(false) ^ process.value >= value.value;
        }
	}
	public class WaitProcessLeaf: TreeProvider<WaitProcess>
    {
    }
}
