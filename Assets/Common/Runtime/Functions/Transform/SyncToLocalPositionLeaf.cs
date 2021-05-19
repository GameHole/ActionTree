using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncToLocalPosition:ATree
	{
        Position position;
        UnityEntity ue;
		public override void Do()
        {
            if (ue)
                ue.transform.localPosition = position.value;
            //this.Log($"p ");
            Condition = true;
        }
	}
	public class SyncToLocalPositionLeaf: TreeProvider<SyncToLocalPosition> { }
}
