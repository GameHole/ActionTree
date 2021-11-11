using System.Collections.Generic;
using System.Text;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
    public sealed class KeyBuilder : IComponent
	{
        public List<string> builder = new List<string>();
        public void Add(string key)
        {
            builder.Add(key);
        }
	}
	public class KeyBuilderPdr: CmpProvider<KeyBuilder> { }
}
