using ActionTree;
using System.Collections.Generic;
using UnityEngine;
namespace Default
{
	public sealed class DevidedCombinedCube:ATree
	{
        CubeCntr cntr;
        CombinedCubeCntr combined;
        public override void Do()
        {
            int v = 0;
            while (v < cntr.array.Length)
            {
                int count = RandomHelper.Range(1, cntr.size + 1);
                CombinedCube cube = new CombinedCube();
                for (int i = 0; i < count; i++)
                {
                    cube.vertxes.Add(cntr.devided(v));
                    v++;
                }
                combined.blocks.Add(cube);
            }
            Condition = true;
        }
	}
	public class DevidedCombinedCubeLeaf: TreeProvider<DevidedCombinedCube> { }
}
