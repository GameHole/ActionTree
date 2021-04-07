﻿using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class SetCurrentPosition:ATree
	{
        MoveToData data;
        Position position;
		public override void Do()
        {
            data.start = position.value;
            Condition = true;
        }
	}
	public class SetCurrentPositionLeaf: TreeProvider<SetCurrentPosition> { }
}
