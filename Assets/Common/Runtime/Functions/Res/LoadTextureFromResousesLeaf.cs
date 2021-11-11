using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class LoadTextureFromResouses:ATree
	{
        Textures textures;
        FilePath path;
		public override void Do()
        {
            textures.values = Resources.LoadAll<Texture>(path.value);
            Condition = true;
        }
	}
	public class LoadTextureFromResousesLeaf: TreeProvider<LoadTextureFromResouses> { }
}
