using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Boolen : IComponent
	{
        public bool value;
	}
    public static class BoolenEx
    {
        public static bool Value(this Boolen boolen)
        {
            if (boolen == null)
            {
                return true;
            }
            return boolen.value;
        }
    }
	public class BoolenPdr: CmpProvider<Boolen> { }
}
