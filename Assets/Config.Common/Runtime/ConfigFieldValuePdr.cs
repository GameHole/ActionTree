using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class ConfigFieldValue : IComponent
	{
        public object value;
	}
	public class ConfigFieldValuePdr: CmpProvider<ConfigFieldValue> { }
}
