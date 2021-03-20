using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
    [System.Serializable]
    public sealed class WaitRaycast : ATree
    {
        public Camera main;
        RaycastData raycast;
        public override void Do()
        {
           
            var ray = main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit/*,100,LayerMask.NameToLayer("Please")*/))
            {
                Debug.DrawLine(ray.origin, hit.point);
                if (raycast != null)
                {
                    raycast.hit = hit;
                }
                Condition = true;
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point,Color.black);
            }
            //Debug.Log("WaitRaycast");
        }
        public override void Clear()
        {
            base.Clear();
            if (raycast != null)
            {
                raycast.hit = default;
            }
        }
    }
	public class WaitRaycastLeaf: TreeProvider<WaitRaycast> { }
}
