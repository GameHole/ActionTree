using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotateVector:ATree
	{
        Vector3Value eular;
        Vector3Value orgion;
        Vector3Value direction;
        Vector3Value output;
        public override void Do()
        {
            output.value = orgion + Quaternion.Euler(eular) * direction;
            Condition = true;
        }
	}
	public class RotateVectorLeaf: TreeProvider<RotateVector> { }
}
