using ActionTree;
using System.Collections.Generic;
using UnityEngine;
namespace Default
{
	public sealed class CombinedCubeCntr : IComponent
	{
        public List<CombinedCube> blocks = new List<CombinedCube>();
	}
	public class CombinedCubeCntrPdr: CmpProvider<CombinedCubeCntr> { }
}
