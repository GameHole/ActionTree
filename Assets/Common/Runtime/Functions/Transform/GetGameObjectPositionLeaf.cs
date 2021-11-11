using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GetGameObjectPosition:ATree
	{
        Position position;
        GameObjectProxy game;
		public override void Do()
        {
            position.value = game.target.transform.position;
            Condition = true;
        }
	}
	public class GetGameObjectPositionLeaf : TreeProvider<GetGameObjectPosition> { }
}
