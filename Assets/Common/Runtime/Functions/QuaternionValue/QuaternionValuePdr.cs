using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class QuaternionValue : Value<Quaternion>
	{
		
	}
	public class QuaternionValuePdr: CmpProvider<QuaternionValue> { }
}
