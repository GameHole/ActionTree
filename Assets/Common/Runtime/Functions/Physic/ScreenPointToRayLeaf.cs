using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ScreenPointToRay:ATree
	{
        CameraProxy proxy;
        RaycastData data;
		public override void Do()
        {
            data.ray = proxy.value.ScreenPointToRay(Input.mousePosition);
            Condition = true;
        }
	}
	public class ScreenPointToRayLeaf: TreeProvider<ScreenPointToRay> { }
}
