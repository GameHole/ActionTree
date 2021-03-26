using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
	public sealed class WaitKey:ATree
	{
        KeyCode key;
        //public override bool isInMain => true;
        public override void Do()
        {
            Condition = Input.GetKey(key.code);
        }
    }
	public class WaitKeyLeaf: TreeProvider<WaitKey> { }
}
