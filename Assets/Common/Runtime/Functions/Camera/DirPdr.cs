using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Dir : FloatValue
	{
        //public float value;
	}
	public class DirPdr: CmpProvider<Dir> { }
}
