using ActionTree;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
    public sealed class UpdatePrePosition : ATree
    {
        PrePosition pre;
        Position position;
        R r;
        Count last;
        Speed speed;
        public override void Do()
        {
            while (pre.values.Count > last.value)
            {
                pre.values.Dequeue();
            }
            float dx = speed.value * deltaTime;
            if (dx < 1e-3f)
                dx = 1e-3f;
            int count = 20;// (int)(r.value * 3 / dx) + 1;
            //Debug.Log($"dx::{dx},count::{count}");
            if (count > 30)
                count = 30;
            last.value = count;
            //if (dx > 0.1)
            //Debug.Log($"dx::{dx},count::{count}");

            pre.values.Enqueue(position.value);
            Condition = true;
        }

    }
	public class UpdatePrePositionLeaf: TreeProvider<UpdatePrePosition> { }
}
