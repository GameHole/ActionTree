using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class LoadInt:ATree
	{
        IntValue value;
        Key key;
        [AllowNull] Boolen overrideOrgionValue;
		public override void Do()
        {
            if (overrideOrgionValue.Value(false)||PlayerPrefs.HasKey(key.value))
                value.value = PlayerPrefs.GetInt(key.value);
            Condition = true;
        }
	}
	public class LoadIntLeaf: TreeProvider<LoadInt> { }
}
