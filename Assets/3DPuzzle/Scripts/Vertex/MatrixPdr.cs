using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Matrix : IComponent
	{
        public MatrixInt value;
	}
	public class MatrixPdr: CmpProvider<Matrix> { }
}
