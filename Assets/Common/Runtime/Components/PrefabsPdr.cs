﻿using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Prefabs : IComponent
	{
        public GameObject[] prefabs;
	}
	public class PrefabsPdr: CmpProvider<Prefabs> { }
}