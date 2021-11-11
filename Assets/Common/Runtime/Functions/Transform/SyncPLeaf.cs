using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncP:ATree
	{
        Position p;
        UnityEntity e;
        //public override bool isInMain => true;
        public override void Do()
        {
            //Debug.Log("aa");
            e.transform.position = p.value;
            Condition = true;
        }
    }
	public class SyncPLeaf: TreeProvider<SyncP> { }
}
