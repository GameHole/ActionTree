﻿using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class LookAt:ATree
	{
        Target target;
        Position position;
        Rotation rotation;
		public override void Do()
        {
            var p = target.value.Get<Position>();
            rotation.value = Quaternion.LookRotation(p.value - position.value);
            Condition = true;
        }
	}
	public class LookAtLeaf: TreeProvider<LookAt> { }
}
