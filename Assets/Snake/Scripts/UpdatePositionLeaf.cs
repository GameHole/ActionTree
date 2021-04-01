using ActionTree;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
    public sealed class UpdatePosition : ATree
    {
        Position position;
        Target target;
        R r;
        LerpedInfo lerped;
        public override void Do()
        {
            var tpp = target.value.Get<PrePosition>();
            var tp = target.value.Get<Position>();

            int state = IndexOf(tpp, tp, out int id);
            if (state == 1 || id == 0)
            {
                position.value = tpp.values[id];
                lerped.exId = lerped.inId = id;
            }
            else if (state == 0)
            {
                if (id > 0)
                {
                    var externalP = tpp.values[id - 1];
                    if ((externalP - tp.value).sqrMagnitude > r.D2)
                    {
                        var internlP = tpp.values[id];
                        var v = externalP - internlP;
                        var nv = v.normalized;
                        Vector3 PN = tp.value - internlP;
                        float R = 2 * r.value;
                        float disInter = Vector3.Dot(PN, nv);
                        Vector3 n = PN - disInter * nv;
                        float d = n.magnitude;
                        float disExter = Mathf.Sqrt((R + d) * (R - d));
                        float len = disExter + disInter;
                        Vector3 M = internlP + len * nv;
                        position.value = M;
                        lerped.exId = id - 1;
                        lerped.inId = id;
                        lerped.t = len / v.magnitude;
                    }
                }
            }
            else
            {
                if (tpp.values.Count == 1)
                {
                    Vector3 dis = tpp.values[tpp.values.Count - 1] - tp.value;
                    float D = r.value * 2;
                    var p = dis.normalized * D + tp.value;
                    position.value = p;
                    lerped.exId = tpp.values.Count - 1;
                    lerped.inId = -1;
                    lerped.t = D / dis.magnitude;
                }
            }
        }
        int IndexOf(PrePosition pre, Position position,out int id)
        {
            id = -1;
            for (int i = 0; i < pre.values.Count; i++)
            {
                var sqDis = (pre.values[i] - position.value).sqrMagnitude;
                if (sqDis < r.D2)
                {
                    id = i;
                    return 0;
                }
                else if (sqDis == r.D2)
                {
                    id = i;
                    return 1;
                }
            }
            return 2;
        }
    }
	public class UpdatePositionLeaf: TreeProvider<UpdatePosition> { }
}
