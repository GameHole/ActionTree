using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class LoadPrefabFromResouses:ATree
	{
        Prefabs prefabs;
        FilePath path;
		public override void Do()
        {
            prefabs.Set(Resources.LoadAll<GameObject>(path.value));
            if (prefabs.Length == 0)
                Debug.LogWarning($"Nothing in floader:Resources/{path.value}");
            Condition = true;
        }
	}
	public class LoadPrefabFromResousesLeaf: TreeProvider<LoadPrefabFromResouses> { }
}
