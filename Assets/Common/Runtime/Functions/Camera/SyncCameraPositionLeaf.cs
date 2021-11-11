using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread(UpdateType.LateUpdate)]
	public sealed class SyncCameraPosition:ATree
	{
        Position position;
        UnityEntity ue;
        [AllowNull] Boolen isLocal;
        public override void Do()
        {
            if (ue)
            {
                if (!isLocal.Value(false))
                    ue.transform.position = position.value;
                else
                    ue.transform.localPosition = position.value;
            }
            Condition = true;
        }
	}
	public class SyncCameraPositionLeaf: TreeProvider<SyncCameraPosition>
    {
    }
}
