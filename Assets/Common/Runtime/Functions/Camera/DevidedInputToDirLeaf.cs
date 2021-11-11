using ActionTree;
using UnityEngine;
namespace ActionTree
{
    public sealed class DevidedInputToDir : ATree
    {
        Dir dir;
        Axis axis;
        DragPadProxy proxy;
        public override void Do()
        {
            dir.value = proxy.direction[axis.value] / 100;
            //this.Log(dir.value);
            Condition = true;
        }
    }
	public class DevidedInputToDirLeaf: TreeProvider<DevidedInputToDir> { }
}
