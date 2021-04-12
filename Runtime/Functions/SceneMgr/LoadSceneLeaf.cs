using ActionTree;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ActionTree
{
    //[MainThread]
	public sealed class LoadScene:ATree
	{
        Identity identity;
		public override void Do()
        {
            driver.postMains.Enqueue(() =>
            {
                Mgr.LoadScene(identity.id);
            });
            Condition = true;
        }
	}
	public class LoadSceneLeaf: TreeProvider<LoadScene> { }
}
