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
           
            bool isCast = Physics.Raycast(ray, out var hit, raycast.maxDistance, raycast.layerMask);
            if (isCast)
            {
                Debug.DrawLine(ray.origin, hit.point);
                if (raycast != null)
                {
                    raycast.hit = hit;
                }
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point,Color.black);
            }
            Condition = isCast;
            //this.Log(Condition);
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
