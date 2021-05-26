using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class cloatv : IComponent
	{
        public float v;
	}
	public class cloatvPdr: CmpProvider<cloatv> { }
}
