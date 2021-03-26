using ActionTree;
using UnityEngine;
namespace Default
{
    //[MainThread]
    public sealed class UpdatePosition : ATree
    {
        Position position;
        Target target;
        R r;
        public override void Do()
        {
            var tpp = target.value.Get<PrePosition>();
            var tp = target.value.Get<Position>();
            //position.value = tpp.values.Peek();
            for (int i = 0; i < tpp.values.Count - 1; i++)
            {
                Vector3 next = tpp.values[i];
                Vector3 pre = tpp.values[i + 1];
                //Debug.Log($"{i} = {(next - tp.value).sqrMagnitude }, { i + 1} = {(pre - tp.value).sqrMagnitude}");
                Vector3 dx = pre - next;
                //int cc = 0;
                for (float t = 0; t < 1; t += 0.05f)
                {
                    //cc++;
                    if ((next + dx * t - tp.value).sqrMagnitude <= r.D2)
                    {
                       // Debug.Log($"c = {cc}");
                        position.value = next + dx * t;
                        return;
                    }
                }
               
            }
        }
    }
	public class UpdatePositionLeaf: TreeProvider<UpdatePosition> { }
}
