using ActionTree;
using UnityEngine;
namespace Default
{
	[MainThread]
    [System.Serializable]
	public sealed class MoveFree:ATree
	{
        Target target;
        public bool condition;
		public override void Do()
        {
            //Debug.Log("MoveFree");
            Vector3 p = Input.mousePosition;
            p.z = -Camera.main.transform.position.z;
            var pv = target.value.GetComponent<Position>();
            pv.value = Camera.main.ScreenToWorldPoint(p);
            Condition = condition;
        }
	}
	public class MoveFreeLeaf: TreeProvider<MoveFree> { }
}
