using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class GameObjectCntr : Array<GameObject>
	{
        //public List<GameObject> games = new List<GameObject>();
	}
	public class GameObjectCntrPdr: CmpProvider<GameObjectCntr> { }
}
