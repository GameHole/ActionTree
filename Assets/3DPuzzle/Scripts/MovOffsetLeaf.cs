using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class MovOffset:ATree
	{
        Offset offset;
        public Vector3Int dir;
		public override void Do()
        {
            offset.value = dir;
            Condition = true;
        }
	}
	public class MovOffsetLeaf: TreeProvider<MovOffset> { }
}
