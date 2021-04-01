using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SyncSpeed:ATree
	{
        Snake snake;
        Speed speed;
		public override void Do()
        {
            for (int i = 0; i < snake.bodys.Count; i++)
            {
                var bd = snake.bodys[i];
                var s = bd.Get<Speed>();
                if (s != null)
                {
                    s.value = speed.value;
                }
            }
        }
	}
	public class SyncSpeedLeaf: TreeProvider<SyncSpeed> { }
}
