using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class DecAxis:ATree
	{
        public int axis;
        Direction d;
        //public override bool isInMain => false;
        public override void Do()
        {
            Condition = true;
            //Debug.Log("dec");
            //var d = entity.GetComponent<Direction>();
            float dx = deltaTime * 10;
            if (Mathf.Abs(d.value[axis]) < dx)
            {
                d.value[axis] = 0;
            }
            else
            {
                float v = d.value[axis];
                float sign = -Mathf.Sign(v);
                d.value[axis] += sign * dx;
            } 
        }
	}
	public class DecAxisLeaf: TreeProvider<DecAxis> { }
}
