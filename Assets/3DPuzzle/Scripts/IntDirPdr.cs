using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class IntDir : IComponent
	{
        public Vector3Int value;
	}
	public class IntDirPdr: CmpProvider<IntDir> { }
}
