using ActionTree;
using UnityEngine;
namespace Default
{
	//[MainThread]
	public sealed class InitCntr:ATree
	{
        CubeCntr cntr;
		public override void Do()
        {
            cntr.size2 = cntr.size * cntr.size;
            int size3 = cntr.size2 * cntr.size;
            cntr.array = new bool[size3];
            Condition = true;
        }
	}
	public class InitCntrLeaf: TreeProvider<InitCntr> { }
}
