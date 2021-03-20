using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class RotateVertix:ATree
	{
        RotateVertex rotate;
        Matrix matrix;
        readonly static int[] sintable = new int[] { 0, 1, 0, -1 };
        readonly static int[] costable = new int[] { 1, 0, -1,0 };
        public override void Do()
        {
            int dx = getIdx(rotate.value.x);
            int sinx = sintable[dx];
            int cosx = costable[dx];
            MatrixInt mx = new MatrixInt(1, 0, 0, 0, 0, cosx, -sinx, 0, 0, sinx, cosx, 0, 0, 0, 0, 1);
            int dy = getIdx(rotate.value.y);
            int siny = sintable[dy];
            int cosy = costable[dy];
            MatrixInt my = new MatrixInt(cosy, 0, -siny, 0, 0, 1, 0, 0, siny, 0, cosy, 0, 0, 0, 0, 1);
            int dz = getIdx(rotate.value.z);
            int sinz = sintable[dz];
            int cosz = costable[dz];
            MatrixInt mz = new MatrixInt(cosz, -sinz, 0, 0, sinz, cosz, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            matrix.value = mx * my * mz;
        }
        int getIdx(int v)
        {
            int r = v % 4;
            if (r < 0)
                r += 4;
            return r;
        }
	}
	public class RotateVertixLeaf: TreeProvider<RotateVertix> { }
}
