using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class And:ATreeCntr
	{
		public override void Do()
        {
            bool v = true;
            for (int i = 0; i < Count; i++)
            {
                var item = trees[i];
                item.Do();
                v &= item.Condition;
            }
            Condition = v;
        }
	}
}
