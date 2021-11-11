using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class ScreenCenterToRay:ATree
    {
        CameraProxy proxy;
        RaycastData data;
        public override void Do()
        {
            data.ray = proxy.value.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f));
            Condition = true;
        }
	}
	public class ScreenCenterToRayLeaf: TreeProvider<ScreenCenterToRay> { }
}
