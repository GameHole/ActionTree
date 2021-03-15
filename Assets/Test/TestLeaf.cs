﻿using ActionTree;
using UnityEngine;
namespace Default
{
	[MainThread]
	public sealed class Test:ATree
	{
		public override void Do()
        {
            Debug.Log("test");
            Condition = true;
        }
	}
	public class TestLeaf: TreeProvider<Test> { }
}