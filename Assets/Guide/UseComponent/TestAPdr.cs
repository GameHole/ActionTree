using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class TestA : IntValue
	{
	}
	public class TestAPdr: CmpProvider<TestA> { }
}
