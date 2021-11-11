using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class DeleteKey:ATree
	{
        Key key;
		public override void Do()
        {
            PlayerPrefs.DeleteKey(key.value);
            Condition = true;
        }
	}
	public class DeleteKeyLeaf: TreeProvider<DeleteKey> { }
}
