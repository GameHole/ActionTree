using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
    [System.Serializable]
	public sealed class WaitMouseUp:ATree
	{
        public int id;
        public override void Do()
        {
            if (Input.GetMouseButtonUp(id))
            {
                Debug.Log("up");
                Condition = true;
            }
        }
    }
	public class WaitMouseUpLeaf: TreeProvider<WaitMouseUp> { }
}
