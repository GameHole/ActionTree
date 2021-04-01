using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class IncAxis:ATree
	{
        public int axis;
        public int sign = 1;
        Direction d;
        //public override bool isInMain => false;
        public override void Do()
        {
            //var d = entity.GetComponent<Direction>();
            if (d.value[axis] > 1)
                d.value[axis] = 1;
            else if(d.value[axis] <-1)
                d.value[axis] = -1;
            d.value[axis] += deltaTime * sign * 10;
            //Debug.Log($"inc {d.value[axis]}");

            Condition = true;
        }
	}
	public class IncAxisLeaf: TreeProvider<IncAxis> { }
}
