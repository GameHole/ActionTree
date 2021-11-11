using ActionTree;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ActionTree
{
	public sealed class LoadSceneAsync:ATree
	{
        IntValue identity;
        FloatValue process; 
        LoadAsyncParam loadAsyncParam;
        [AllowNull] Boolen allowAutoActive;
        bool isLoaded;
		public override void Do()
        {
            if (isLoaded) return;
            isLoaded = true;
            Mgr.postMains.Enqueue(() =>
            {
                Mgr.RemoveEntities();
                Mgr.singleInstance.StartCoroutine(LoadScene(identity.value));
            });
        }

        System.Collections.IEnumerator LoadScene(int id)
        {
            var aop = SceneManager.LoadSceneAsync(identity.value);
            aop.allowSceneActivation = false;
            loadAsyncParam.operation = aop;
            var waitFrame = new WaitForEndOfFrame();
            while (true)
            {
                process.value = aop.progress / 0.9f;
                //this.Log(process.value);
                if (process.value >= 1) break;
                yield return waitFrame;
            }
            bool allow = allowAutoActive.Value(false);
            aop.allowSceneActivation = allow;
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            isLoaded = false;
        }
    }
	public class LoadSceneAsyncLeaf: TreeProvider<LoadSceneAsync> { }
}
