using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class LoadState:ATree
	{
        State state;
        Key key;
        [AllowNull] IntValue defaultV;
		public override void Do()
        {
            state.value = PlayerPrefs.GetInt(key.value, defaultV == null ? 0 : defaultV.value);
            Condition = true;
        }
	}
	public class LoadStateLeaf: TreeProvider<LoadState> { }
}
