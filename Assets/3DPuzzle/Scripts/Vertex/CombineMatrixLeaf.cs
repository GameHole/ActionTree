using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class CombineMatrix:ATree
	{
        LocalVertex local;
        Matrix matrix;
        Vertex vertex;
		public override void Do()
        {
            vertex.value = matrix.value * new Vector4Int(local.value, 1);
        }
	}
	public class CombineMatrixLeaf: TreeProvider<CombineMatrix> { }
}
