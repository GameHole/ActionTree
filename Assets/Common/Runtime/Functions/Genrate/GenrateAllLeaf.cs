using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class GenrateAll : ATree
    {
        Prefabs prefabs;
        [AllowNull]EntitiesCntr cntr;
        //GameObjectCntr objCntr;
        public override void Do()
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                var clone = Object.Instantiate(prefabs[i]);
                var ue = clone.GetComponent<UnityEntity>();
                if (cntr != null && ue != null)
                {
                    ue.InitOnce();
                    cntr.value.Add(ue.entity);
                }
                //if (objCntr != null)
                //{
                //    objCntr.games.Add(clone);
                //}
            }
            Condition = true;
        }
    }
	public class GenrateAllLeaf: TreeProvider<GenrateAll> { }
}
