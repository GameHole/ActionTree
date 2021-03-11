using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class WaitKeyDown:ATree
	{
        public KeyCode key;
        public bool isDown;
		public override void Do()
        {
            Condition = isDown ? Input.GetKeyDown(key) : Input.GetKeyUp(key);
        }
	}
	public class WaitKeyDownLeaf: TreeProvider<WaitKeyDown> { }
}
