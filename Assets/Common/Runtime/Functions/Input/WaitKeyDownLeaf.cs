using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitKeyDown:ATree
	{
        KeyCode key;
        Boolen isDown;
		public override void Do()
        {
            Condition = isDown.Value() ? Input.GetKeyDown(key.code) : Input.GetKeyUp(key.code);
        }
	}
	public class WaitKeyDownLeaf: TreeProvider<WaitKeyDown> { }
}
