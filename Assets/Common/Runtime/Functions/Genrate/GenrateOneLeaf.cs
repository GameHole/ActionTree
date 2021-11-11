using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GenrateOne:ATree
	{
        Prefabs prefabs;
        IntValue index;
        [AllowNull]EntitiesCntr cntr;
        [AllowNull]GameObjectProxy game;
		public override void Do()
        {
            var prefab = prefabs[index];
            var clone = Object.Instantiate(prefab);
            clone.name = prefab.name;
            if (game!=null)
            {
                game.target = clone;
            }
            var e = clone.GetComponentInChildren<UnityEntity>();
            if (e)
            {
                e.InitOnce();
                if (cntr != null)
                {
                    cntr.value.Add(e.entity);
                }
            }
            Condition = true;
        }
    }
	public class GenrateOneLeaf: TreeProvider<GenrateOne> { }
}
