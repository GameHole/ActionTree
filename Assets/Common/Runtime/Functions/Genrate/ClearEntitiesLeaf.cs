using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class ClearEntities:ATree
	{
        EntitiesCntr cntr;
		public override void Do()
        {
            cntr.value.Clear();
            Condition = true;
        }
	}
	public class ClearEntitiesLeaf: TreeProvider<ClearEntities> { }
}
