using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class WaitRaycast : ATree
    {
        //public Camera main;
        RaycastData raycast;
        public override void Do()
        {
            var ray = raycast.ray;
            //this.Log(ray);
            if (Physics.Raycast(ray, out var hit, raycast.maxDistance, raycast.layerMask))
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
