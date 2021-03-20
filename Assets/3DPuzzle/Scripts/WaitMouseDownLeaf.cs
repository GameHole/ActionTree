using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
    [System.Serializable]
	public sealed class WaitMouseDown:ATree
	{
        public int id;
		public override void Do()
        {
            if (Input.GetMouseButtonDown(id))
            {
                Debug.Log("down");
                Condition = true;
            }  
        }
    }
	public class WaitMouseDownLeaf: TreeProvider<WaitMouseDown> { }
}
