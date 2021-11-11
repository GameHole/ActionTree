using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GenrateGameObjects:ATree
	{
        Prefabs prefabs;
        GameObjectCntr cntr;
		public override void Do()
        {
            foreach (var item in prefabs)
            {
                cntr.value.Add(Object.Instantiate(item));
            }
            Condition = true;
        }
	}
	public class GenrateGameObjectsLeaf: TreeProvider<GenrateGameObjects> { }
}
