using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class FocusedScroll : IComponent
	{
        public Transform gp;
	}
	public class FocusedScrollPdr: CmpProvider<FocusedScroll> { }
}
