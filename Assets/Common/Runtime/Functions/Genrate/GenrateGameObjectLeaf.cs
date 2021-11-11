using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GenrateGameObject:ATree
	{
        GameObjectProxy proxy;
        Prefabs prefabs;
        IntValue index;
		public override void Do()
        {
            proxy.target = Object.Instantiate(prefabs[index]);
            Condition = true;
        }
	}
	public class GenrateGameObjectLeaf: TreeProvider<GenrateGameObject> { }
}
