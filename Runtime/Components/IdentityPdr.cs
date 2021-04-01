using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Identity : IComponent
	{
        public int id;
	}
	public class IdentityPdr: CmpProvider<Identity> { }
}
