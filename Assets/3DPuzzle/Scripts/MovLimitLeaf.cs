using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[MainThread]
	public sealed class MovLimit:ATree
	{
        Target target;
        RaycastData data;
        public override void Do()
        {
            var ui = target.value.Get<CombinedCubeUI>();
            var cntr = driver.FindFirstCmp<CubeCntr>();
            var id = data.hit.collider.GetComponent<Id>();
            ui.Offset = cntr.devided(id.value);
            ui.SetEnable(true);
            Condition = false;
        }
	}
	public class MovLimitLeaf: TreeProvider<MovLimit> { }
}
