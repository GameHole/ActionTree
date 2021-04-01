using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class MovVertix:ATree
	{
        Offset offset;
        Matrix matrix;
		public override void Do()
        {
           
            matrix.value.m03 = offset.value.x;
            matrix.value.m13 = offset.value.y;
            matrix.value.m23 = offset.value.z;
        }
	}
	public class MovVertixLeaf: TreeProvider<MovVertix> { }
}
