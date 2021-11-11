using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class AnimDriveData : FloatValue
	{
        public Vector2 increaseRange = new Vector2(0, 1);
        //public float increase;
    }
	public class AnimDriveDataPdr: CmpProvider<AnimDriveData> { }
}
