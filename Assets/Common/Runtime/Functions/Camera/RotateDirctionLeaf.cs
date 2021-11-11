using ActionTree;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotateDirction:ATree
	{
        EulerAngle rotation;
        Direction direction;
        Position position;
        [AllowNull]Target target;
		public override void Do()
        {
            Vector3 org = Vector3.zero;
            if (target != null)
                org = target.Get<Position>().value;
            position.value = org + Quaternion.Euler(rotation.value) * direction.value;
            Condition = true;
        }
    }
	public class RotateDirctionLeaf: TreeProvider<RotateDirction> { }
}
