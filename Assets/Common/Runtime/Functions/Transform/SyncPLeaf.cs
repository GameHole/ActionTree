using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncP:ATree
	{
        Position p;
        UnityEntity e;
        [AllowNull]Boolen menual;
        //public override bool isInMain => true;
        public override void Do()
        {
            //Debug.Log("aa");
            e.transform.position = p.value;
            Condition = menual.Value();
        }
    }
	public class SyncPLeaf: TreeProvider<SyncP> { }
}
