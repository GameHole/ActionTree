using ActionTree;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ActionTree
{
	public sealed class WaitSceneLoaded:ATree
	{
        //Identity identity;
		public override void Do() { }
        public void onLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.sceneLoaded -= onLoaded;
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            SceneManager.sceneLoaded += onLoaded;
        }
    }
	public class WaitSceneLoadedLeaf: TreeProvider<WaitSceneLoaded>
    {
        public override ITree GetTree()
        {
            SceneManager.sceneLoaded += value.onLoaded;
            return base.GetTree();
        }
    }
}
