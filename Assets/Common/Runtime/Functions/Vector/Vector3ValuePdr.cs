using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class Vector3Value : Value<Vector3>
	{
        //public Vector3 value;
	}
	public class Vector3ValuePdr: CmpProvider<Vector3Value> { }
}
