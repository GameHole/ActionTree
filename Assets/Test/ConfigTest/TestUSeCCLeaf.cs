using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TestUSeCC:ATree
	{
        public Config<CCC> cs;
		public override void Do()
        {
            if (driver.TryFindFirstCmp(ref cs))
            {
                for (int i = 0; i < cs.Length; i++)
                {
                    cs[i].debug();
                }
                Condition = true;
            }
        }
	}
	public class TestUSeCCLeaf: TreeProvider<TestUSeCC> { }
}
