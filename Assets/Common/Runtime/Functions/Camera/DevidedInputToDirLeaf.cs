using ActionTree;
using UnityEngine;
namespace ActionTree
{
    public sealed class DevidedInputToDir : ATree
    {
        Dir dir;
        Axis axis;
        DragPadProxy proxy;
        FloatValue sencity;
        public override void Do()
        {
            dir.value = proxy.direction[axis.value] * sencity;
            //this.Log(dir.value);
            Condition = true;
        }
    }
	public class DevidedInputToDirLeaf: TreeProvider<DevidedInputToDir> { }
}
