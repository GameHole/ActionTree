﻿using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class UnityActive:ATree
	{
        GameObjectProxy proxy;
        Boolen active;
		public override void Do()
        {
            proxy.target.SetActive(active.value);
            Condition = true; 
        }
    }
	public class UnityActiveLeaf: TreeProvider<UnityActive> { }
}
