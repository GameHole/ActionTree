using ActionTree;
using UnityEngine;
namespace ActionTree
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
