using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class PlayAnimByName:ATree
	{
        StringValue name;
        FloatValue start;
        AnimatorProxy proxy;
		public override void Do()
        {
            proxy.animator.speed = proxy.speed;
            proxy.animator.Play(name, 0, start);
            Condition = true;
        }
	}
	public class PlayAnimByNameLeaf: TreeProvider<PlayAnimByName> { }
}
