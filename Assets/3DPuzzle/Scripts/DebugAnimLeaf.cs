using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class DebugAnim:ATree
	{
        public bool isOut;
		public override void Do()
        {
            //Condition = true;
            string m;
            if (isOut)
            {
                m = "anim out ";
            }
            else
            {
                m = "anim in ";
            }
            Debug.Log(m);
        }
	}
	public class DebugAnimLeaf: TreeProvider<DebugAnim> { }
}
