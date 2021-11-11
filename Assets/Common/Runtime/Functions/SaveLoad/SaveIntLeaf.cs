using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SaveInt:ATree
	{
        IntValue value;
        Key key;
		public override void Do()
        {
            PlayerPrefs.SetInt(key.value, value);
            Condition = true;
        }
	}
	public class SaveIntLeaf: TreeProvider<SaveInt> { }
}
