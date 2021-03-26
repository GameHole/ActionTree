using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
	public sealed class DebugDraw:ATree
	{
        //Position position;
        PrePosition pre;
		public override void Do()
        {
            var c = new Color(Random.Range(0f, 1), Random.Range(0f, 1), Random.Range(0f, 1), 1);
            for (int i = 0; i < pre.values.Count-1; i++)
            {
                Debug.DrawLine(pre.values[i], pre.values[i + 1],c );
                Debug.DrawLine(pre.values[i], pre.values[i]+Vector3.up, c);
            }
            Condition = true;
        }
	}
	public class DebugDrawLeaf: TreeProvider<DebugDraw> { }
}
