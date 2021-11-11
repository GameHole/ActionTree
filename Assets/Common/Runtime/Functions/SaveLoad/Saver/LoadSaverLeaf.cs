using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LoadSaver:ATree
	{
        DataSaver saver;
		public override void Do()
        {
            saver.Init();
            Condition = true;
        }
	}
	public class LoadSaverLeaf: TreeProvider<LoadSaver> { }
}
