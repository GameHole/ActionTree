using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SaveSaver:ATree
	{
        DataSaver saver; 
		public override void Do()
        {
            saver.Save();
            Condition = true;
        }
	}
	public class SaveSaverLeaf: TreeProvider<SaveSaver> { }
}
