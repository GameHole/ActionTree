﻿using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public class Boolen : IComponent
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
