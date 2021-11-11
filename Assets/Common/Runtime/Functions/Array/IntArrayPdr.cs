using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Washer
{
	[System.Serializable]
	public sealed class IntArray : Array<int>
	{
		
	}
	public class IntArrayPdr: CmpProvider<IntArray> { }
}
