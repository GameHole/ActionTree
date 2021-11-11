using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SaveFloat:ATree
	{
        Key key;
        FloatValue value;
		public override void Do()
        {
            PlayerPrefs.SetFloat(key.value, value.value);
            Condition = true;
        }
	}
	public class SaveFloatLeaf: TreeProvider<SaveFloat> { }
}
