using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class TransformWithRotate:ATree
	{
        Target[] camera;
        Offset offset;
        //Target target;
        public override void Do()
        {
            var rot = camera[1].value.Get<Rotation>();
            Vector3 off = rot.value * offset.value;
            //Debug.Log($"r {rotation.value} off （{off.x }，{off.y }，{off.z }） {Vector3Int.RoundToInt(off)}");
            var ui = camera[0].value.Get<CombinedCubeUI>();
            ui.Offset += Vector3Int.RoundToInt(off);
            Condition = true;
        }
	}
	public class TransformWithRotateLeaf: TreeProvider<TransformWithRotate>
    {
        //public RotationPdr pdr;
        //public override ETree GetTree()
        //{
        //    value.targetRot = pdr.value;
        //    return base.GetTree();
        //}
    }
}
