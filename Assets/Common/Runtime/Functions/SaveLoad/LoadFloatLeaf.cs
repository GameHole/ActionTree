using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class LoadFloat:ATree
	{
        [AllowNull]FloatValue defaultV;
        FloatValue value;
        Key key;
		public override void Do()
        {
            value.value = PlayerPrefs.GetFloat(key.value,defaultV.zero());
            Condition = true;
        }
	}
	public class LoadFloatLeaf: TreeProvider<LoadFloat> { }
}
