using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
    [MainThread]
	public sealed class CreateCube:ATree
	{
        CubeCntr cntr;
        CubePrefab cprefab;
        public override void Do()
        {
            //Debug.Log("aaaa");
            cprefab.uis = new Id[cntr.array.Length];
            for (int i = 0; i < cntr.array.Length; i++)
            {
                var clone = Object.Instantiate(cprefab.prefabs);
                clone.transform.position = cntr.devided(i) - Vector3.one * (cntr.size / 2 - 0.5f);
                clone.value = i;
                cprefab.uis[i] = clone;
                clone.transform.SetParent(cprefab.parent, true);
            }
            Condition = true;
        }
    }
	public class CreateCubeLeaf: TreeProvider<CreateCube> { }
}
