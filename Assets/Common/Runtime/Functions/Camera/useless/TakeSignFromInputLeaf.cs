using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TakeSignFromInput:ATree
	{
        DragPadProxy proxy;
        Sign sign;
        Axis axis;
		public override void Do()
        {
            sign.value = Mathf.Sign(proxy.direction[axis.value]);
            Condition = true;
        }
	}
	public class TakeSignFromInputLeaf: TreeProvider<TakeSignFromInput> { }
}
