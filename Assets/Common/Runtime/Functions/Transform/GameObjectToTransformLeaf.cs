using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GameObjectToTransform:ATree
	{
        GameObjectProxy game;
        UnityParent tran;
		public override void Do()
        {
            tran.value = game.target.transform;
            Condition = true;
        }
	}
	public class GameObjectToTransformLeaf: TreeProvider<GameObjectToTransform> { }
}
