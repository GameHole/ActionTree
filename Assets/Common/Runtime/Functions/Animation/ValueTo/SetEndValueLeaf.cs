using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
	public sealed class SetEndValue:ATree
	{
        FloatValue end;
        FloatToData floatTo;
        public override void Do()
        {
            floatTo.end = end;
            Condition = true;
        }
	}
	public class SetEndValueLeaf: TreeProvider<SetEndValue> { }
}
