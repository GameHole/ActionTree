using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class TestB : IntValue
	{
	}
	public class TestBPdr: CmpProvider<TestB> { }
}
