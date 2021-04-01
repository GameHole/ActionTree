using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class MovOffset:ATree
	{
        Offset offset;
        IntDir dir;
		public override void Do()
        {
            offset.value += dir.value;
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            offset.value = Vector3Int.zero;
        }
    }
	public class MovOffsetLeaf: TreeProvider<MovOffset> { }
}
