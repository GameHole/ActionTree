using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class EntitiesCntr : Array<Entity>
	{
        //public List<Entity> entities = new List<Entity>();
        //public List<Entity> GetEntities() => entities;
    }
	public class EntitiesCntrPdr: CmpProvider<EntitiesCntr> { }
}
