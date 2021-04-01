using ActionTree;
using UnityEngine;
namespace ActionTree
{
    public enum BtnAction
    {
        Down,Up
    }

    [System.Serializable]
	public sealed class WaitImgDown:ATree
	{
        public Click click;
        public BtnAction action;
        public override void Do()
        {
            if (action == BtnAction.Down)
                Condition = click.isDown;
            else
                Condition = click.isUp;
        }
	}
	public class WaitImgDownLeaf: TreeProvider<WaitImgDown> { }
}
