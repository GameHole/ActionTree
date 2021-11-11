using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Washer
{
	//[System.Serializable]
	public sealed class IntStack : AStack<int>
	{
		
	}
	public class IntStackPdr: CmpProvider<IntStack> { }
}
