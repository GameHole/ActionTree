using ActionTree;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class DebugDrawCombined:ATree
	{
        CombinedCubeCntr cntr;
		public override void Do()
        {
            float b = 5;
            for (int i = 0; i < cntr.blocks.Count; i++)
            {
                var c = cntr.blocks[i];
                b += 5;
                for (int j = 0; j < c.vertxes.Count; j++)
                {
                    var clone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    clone.name = "debug";
                    clone.transform.position = new Vector3(b , 0, 0) + c.vertxes[j];
                }
            }
            Condition = true;
        }
	}
	public class DebugDrawCombinedLeaf: TreeProvider<DebugDrawCombined> { }
}
