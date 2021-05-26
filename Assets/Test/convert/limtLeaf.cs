using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class limt:ATree
	{
        cloatv _cloatv;
		public override void Do()
        {
            _cloatv.v = 100;
            Condition = true;
        }
        public override void Apply()
        {
            _cloatv = entity.FindImplement<cloatv>();
        }
    }
	public class limtLeaf: TreeProvider<limt> { }
}
