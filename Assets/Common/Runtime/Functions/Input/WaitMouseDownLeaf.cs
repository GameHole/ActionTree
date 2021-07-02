using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    [System.Serializable]
	public sealed class WaitMouseDown:ATree
	{
        Identity id;
		public override void Do()
        {
            if (Input.GetMouseButtonDown(id.value))
            {
                Debug.Log("down");
                Condition = true;
            }  
        }
    }
	public class WaitMouseDownLeaf: TreeProvider<WaitMouseDown> { }
}
