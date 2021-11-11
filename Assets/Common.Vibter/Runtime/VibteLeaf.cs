using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
    [MainThread]
	public sealed class Vibte:ATree
	{
        IntValue mstime;
		public override void Do()
        {
            Vibrator.Vibrate(mstime, 1);
            Condition = true;
        }
	}
	public class VibteLeaf: TreeProvider<Vibte> { }
}
