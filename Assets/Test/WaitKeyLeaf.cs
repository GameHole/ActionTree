using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
    [MainThread]
	public sealed class WaitKey:ATree
	{
        public KeyCode key;
        //public override bool isInMain => true;
        public override void Do()
        {
            //Debug.Log("key");
            Condition = Input.GetKey(key);
        }
    }
	public class WaitKeyLeaf: TreeProvider<WaitKey> { }
}
