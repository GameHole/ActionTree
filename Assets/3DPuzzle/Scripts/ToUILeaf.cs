﻿using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class ToUI:ATree
	{
        LocalVertex local;
        Vertex vertex;
        Position position;
		public override void Do()
        {
            position.value = vertex.value;
        }
	}
	public class ToUILeaf: TreeProvider<ToUI> { }
}
