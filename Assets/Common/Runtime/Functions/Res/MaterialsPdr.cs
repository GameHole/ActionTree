using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Materials : Array<Material>
	{
        //public Material[] materials;
	}
	public class MaterialsPdr: CmpProvider<Materials> { }
}
