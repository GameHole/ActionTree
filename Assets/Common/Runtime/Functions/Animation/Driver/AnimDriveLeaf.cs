using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AnimDrive:ATree
	{
        AnimDriveData data;
        [AllowNull] Speed speed;
        public override void Do()
        {
            data.value += deltaTime * speed.Speed();
            data.value = Mathf.Clamp(data.value, data.increaseRange.x, data.increaseRange.y);
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            data.value = 0;
        }
    }
	public class AnimDriveLeaf: TreeProvider<AnimDrive> { }
}
