using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class Move:ATree
	{
        Direction d;
        Speed s;
        Position p;
        //public override bool isInMain => false;
        public override void Do()
        {
            //Debug.Log($"mov  {d.value}");
            //var e = entity.GetComponent<UnityEntity>();
            //var d = entity.GetComponent<Direction>();
            //var s = entity.GetComponent<Speed>();
            p.value += d.value * s.value * deltaTime;
            //Debug.Log(p.value);
            Condition = true;
        }
	}
	public class MoveLeaf: TreeProvider<Move> { }
}
