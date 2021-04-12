using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class ComponentProxy : IComponent
	{
        public Component value;
        public T Value<T>()where T : Object
        {
            return value as T;
        }
	}
	public class UnityComponentProxyPdr : CmpProvider<ComponentProxy>
    {
    }
}
