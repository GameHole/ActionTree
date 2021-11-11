using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ActiveCount:ATree
	{
        IntValue count;
        GameObjectCntr games;
		public override void Do()
        {
            int i = 0;
            int c = Mathf.Min(count, games.Length);
            for (; i < c; i++)
            {
                games[i].SetActive(true);
            }
            for (; i < games.Length; i++)
            {
                games[i].SetActive(false);
            }
            Condition = true;
        }
	}
	public class ActiveCountLeaf: TreeProvider<ActiveCount> { }
}
