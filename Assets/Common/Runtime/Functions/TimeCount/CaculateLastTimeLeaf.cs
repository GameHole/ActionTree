using ActionTree;
//using UnityEngine;
namespace CrashSimulator
{
	public sealed class CaculateLastTime:ATree
	{
        LastTime lastTime;
        Time time;
		public override void Do()
        {
            lastTime.value = time.time - time.add;
            Condition = true;
        }
	}
	public class CaculateLastTimeLeaf: TreeProvider<CaculateLastTime> { }
}
