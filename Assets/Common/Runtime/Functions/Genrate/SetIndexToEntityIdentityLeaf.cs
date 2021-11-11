using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetIndexToEntityIdentity:ATree
	{
        EntitiesCntr cntr;
        IntValue index;
        public override void Do()
        {
            var e = cntr.value[index];
            e.Get<Identity>().value = index;
            Condition = true;
        }
    }
	public class SetIndexToEntityIdentityLeaf: TreeProvider<SetIndexToEntityIdentity> { }
}
