using ActionTree;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
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
                Vector3Int c = Vector3Int.zero;
                for (int i = 0; i < count; i++)
                {
                    if (i == 0)
                    {
                        c = cntr.devided(v);
                        cube.vertxes.Add(Vector3Int.zero);
                    }
                    else
                    {
                        cube.vertxes.Add(cntr.devided(v) - c);
                    }
                    v++;
                }
                combined.blocks.Add(cube);
            }
            Condition = true;
        }
	}
	public class DevidedCombinedCubeLeaf: TreeProvider<DevidedCombinedCube> { }
}
