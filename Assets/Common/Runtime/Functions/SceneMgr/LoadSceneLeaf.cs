using ActionTree;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ActionTree
{
    //[MainThread]
	public sealed class LoadScene:ATree
	{
        Identity identity;
        bool isRuned;
		public override void Do()
        {
            if (isRuned) return;
            isRuned = true;
            Mgr.postMains.Enqueue(() =>
            {
                SceneManager.sceneLoaded += onLoaded;
                Mgr.LoadScene(identity.id);
            });
        }
        private void onLoaded(Scene arg0, LoadSceneMode arg1)
        {
            //Debug.Log("loaded");
            Condition = true;
            SceneManager.sceneLoaded -= onLoaded;
        }

        public override void Clear()
        {
            base.Clear();
            isRuned = false;
        }
    }
	public class LoadSceneLeaf: TreeProvider<LoadScene> { }
}
