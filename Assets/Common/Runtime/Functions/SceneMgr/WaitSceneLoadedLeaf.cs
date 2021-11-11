using ActionTree;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ActionTree
{
	public sealed class WaitSceneLoaded:ATree
	{
        //Identity identity;
        bool isInited;
		public override void Do()
        {
            if (isInited) return;
            isInited = true;
            SceneManager.sceneLoaded += onLoaded;
        }
        public void onLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.sceneLoaded -= onLoaded;
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            isInited = false;
            //SceneManager.sceneLoaded += onLoaded;
        }
    }
	public class WaitSceneLoadedLeaf: TreeProvider<WaitSceneLoaded>
    {
        //public override ITree GetTree()
        //{
            
        //    return base.GetTree();
        //}
    }
}
