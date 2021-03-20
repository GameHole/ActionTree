using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class LookAt:ATree
	{
        Target target;
        Position position;
        Rotation rotation;
		public override void Do()
        {
            var p = target.value.GetComponent<Position>();
            rotation.value = Quaternion.LookRotation(p.value - position.value);
        }
	}
	public class LookAtLeaf: TreeProvider<LookAt> { }
}
