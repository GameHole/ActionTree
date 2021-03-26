using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
    [System.Serializable]
	public sealed class WaitMouseDown:ATree
	{
        Identity id;
		public override void Do()
        {
            if (Input.GetMouseButtonDown(id.id))
            {
                Debug.Log("down");
                Condition = true;
            }  
        }
    }
	public class WaitMouseDownLeaf: TreeProvider<WaitMouseDown> { }
}
