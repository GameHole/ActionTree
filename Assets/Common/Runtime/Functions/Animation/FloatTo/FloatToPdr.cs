using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class FloatToData : IComponent
	{
        public float start;
        public float end;
        public bool useDir;
        public float dir;
	}
	public class FloatToPdr: CmpProvider<FloatToData> { }
}
