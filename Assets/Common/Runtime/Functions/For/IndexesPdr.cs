using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Indexes : Array<int>
	{
        //public int[] values;
	}
	public class IndexesPdr: CmpProvider<Indexes> { }
}
