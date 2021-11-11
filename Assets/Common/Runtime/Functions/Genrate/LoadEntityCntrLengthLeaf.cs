using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LoadEntityCntrLength:ATree
	{
        EntitiesCntr cntr;
        IntValue len;
		public override void Do()
        {
            len.value = cntr.Length;
            Condition = true;
        }
	}
	public class LoadEntityCntrLengthLeaf: TreeProvider<LoadEntityCntrLength> { }
}
