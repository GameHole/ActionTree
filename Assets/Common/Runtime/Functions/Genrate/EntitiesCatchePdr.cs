using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class EntitiesCatche : IComponent
	{
        public List<Entity> entities = new List<Entity>();
	}
	public class EntitiesCatchePdr: CmpProvider<EntitiesCatche> { }
}
