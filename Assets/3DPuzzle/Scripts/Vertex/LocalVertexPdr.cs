﻿using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class LocalVertex : IComponent
	{
        public Vector3Int value;
	}
	public class LocalVertexPdr: CmpProvider<LocalVertex> { }
}
