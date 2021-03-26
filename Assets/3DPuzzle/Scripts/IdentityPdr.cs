using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Identity : IComponent
	{
        public int id;
	}
	public class IdentityPdr: CmpProvider<Identity> { }
}
