﻿using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetButtonEnable:ATree
	{
        ButtonProxy proxy;
        Boolen value;
		public override void Do()
        {
            proxy.button.interactable = value.value;
            Condition = true;
        }
	}
	public class SetButtonEnableLeaf: TreeProvider<SetButtonEnable> { }
}
