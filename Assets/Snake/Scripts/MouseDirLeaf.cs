using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class MouseDir:ATree
	{
        Direction direction;
        Speed speed;
		public override void Do()
        {
            direction.value = (Input.mousePosition - new Vector3(Screen.width, Screen.height, 0) * 0.5f).normalized;
        }
	}
	public class MouseDirLeaf: TreeProvider<MouseDir> { }
}
