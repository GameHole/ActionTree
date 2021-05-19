using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class FomatProcess:ATree
	{
        Process process;
        Format format;
		public override void Do()
        {
            format[0] = ((int)(process.value * 100)).ToString();
            Condition = true;
        }
	}
	public class FomatProcessLeaf: TreeProvider<FomatProcess> { }
}
