using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
    [MainThread]
	public sealed class SyncP:ATree
	{
        Position p;
        UnityEntity e;
        //public override bool isInMain => true;
        public override void Do()
        {
            //Debug.Log($"e {e} p {p}");
            e.transform.position = p.value;
            Condition = true;
        }
    }
	public class SyncPLeaf: TreeProvider<SyncP> { }
}
