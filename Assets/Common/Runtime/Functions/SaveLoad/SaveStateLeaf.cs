using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SaveState:ATree
	{
        Key key;
        State state;
		public override void Do()
        {
            PlayerPrefs.SetInt(key.value, state.value);
            Condition = true;
        }
	}
	public class SaveStateLeaf: TreeProvider<SaveState> { }
}
