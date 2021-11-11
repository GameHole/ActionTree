using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetEntitiesParent:ATree
	{
        UnityParent uparent;
        EntitiesCntr cntr;
        public override void Do()
        {
            //this.Log(cntr.entities.Count);
            for (int i = 0; i < cntr.Length; i++)
            {
                var tran = cntr[i].Get<UnityEntity>().transform;
                tran.SetParent(uparent.value);
            }
            Condition = true;
        }
	}
	public class SetEntitiesParentLeaf: TreeProvider<SetEntitiesParent> { }
}
