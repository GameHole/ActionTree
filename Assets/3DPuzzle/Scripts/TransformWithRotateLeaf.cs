using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class TransformWithRotate:ATree
	{
        public Rotation rotation;
        Offset offset;
        Target target;
		public override void Do()
        {
            Vector3 off = rotation.value * offset.value;
            var ui=target.value.GetComponent<CombinedCubeUI>();
            ui.Offset += Vector3Int.FloorToInt(off);
            Debug.Log(Vector3Int.FloorToInt(off));
            Condition = true;
        }
	}
	public class TransformWithRotateLeaf: TreeProvider<TransformWithRotate>
    {
        public RotationPdr pdr;
        public override ITree GetTree()
        {
            value.rotation = pdr.value;
            return base.GetTree();
        }
    }
}
