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
           
            if (Physics.Raycast(ray, out var hit))
            {
                Debug.Log("cast");
                Debug.DrawLine(ray.origin, hit.point);
                if (raycast != null)
                {
                    raycast.hit = hit;
                    Debug.Log(hit.point);
                }
                Condition = true;
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point,Color.black);
            }
            //Debug.Log(Condition);
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
