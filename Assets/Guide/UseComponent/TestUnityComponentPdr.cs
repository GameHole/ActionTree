using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace ActionTree
{
	[System.Serializable]
	public sealed class TestUnityComponent : IComponent
	{
        public Text text;
	}
	public class TestUnityComponentPdr: CmpProvider<TestUnityComponent> { }
}
