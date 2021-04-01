using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitAllOk:ATree
	{
        CubeCntr cube;
		public override void Do()
        {

            for (int i = 0; i < cube.array.Length; i++)
            {
               
                if (!cube.array[i])
                {
                    Condition = false;
                    return;
                }
            }
            Condition = true;
        }
	}
	public class WaitAllOkLeaf: TreeProvider<WaitAllOk> { }
}
