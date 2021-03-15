using ActionTree;
using UnityEngine;
namespace Default
{
	[MainThread]
    [System.Serializable]
	public sealed class TestMain:ATree
	{
        public int id;
		public override void Do()
        {
            Condition = true;
            Debug.Log($"TestMain{id}");
        }
	}
	public class TestMainLeaf: TreeProvider<TestMain> { }
}
