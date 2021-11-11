using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncPosition:ATree
	{
        Position position;
        GameObjectProxy go;
		public override void Do()
        {
            go.target.transform.position = position;
            Condition = true;
        }
	}
	public class SyncPositionLeaf: TreeProvider<SyncPosition> { }
}
