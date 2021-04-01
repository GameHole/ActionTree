using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    [System.Serializable]
	public sealed class WaitMouseUp:ATree
	{
        Identity id;
        public override void Do()
        {
            if (Input.GetMouseButtonUp(id.id))
            {
                Debug.Log("up");
                Condition = true;
            }
        }
    }
	public class WaitMouseUpLeaf: TreeProvider<WaitMouseUp> { }
}
