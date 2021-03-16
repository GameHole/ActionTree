using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class SelectId : IComponent
	{
        public int value;
        public Transform genedcube;
	}
	public class SelectIdPdr: CmpProvider<SelectId> { }
}
