using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class SelectId : IComponent
	{
        public int value;
	}
	public class SelectIdPdr: CmpProvider<SelectId> { }
}
