using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetEntityLocalScale:ATree
	{
        EntitiesCntr cntr;
        IntValue index;
        public override void Do()
        {
            var e = cntr[index];
            e.Get<UnityEntity>().transform.localScale = Vector3.one;
            Condition = true;
        }
    }
	public class SetEntityLocalScaleLeaf: TreeProvider<SetEntityLocalScale> { }
}
