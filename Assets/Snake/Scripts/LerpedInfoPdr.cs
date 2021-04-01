using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class LerpedInfo : IComponent
	{
        public int exId;
        public int inId;
        public float t;
	}
	public class LerpedInfoPdr: CmpProvider<LerpedInfo> { }
}
