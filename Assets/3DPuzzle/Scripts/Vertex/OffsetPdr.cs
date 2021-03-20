using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class Offset : IComponent
	{
        public Vector3Int value;
	}
	public class OffsetPdr: CmpProvider<Offset> { }
}
