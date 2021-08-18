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
            Condition = Input.GetMouseButtonUp(id.value);
        }
    }
	public class WaitMouseUpLeaf: TreeProvider<WaitMouseUp> { }
}
