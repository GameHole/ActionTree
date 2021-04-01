using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class OperateData : IComponent
	{
        public Vector3Int offset;
        public MatrixInt rotate;
	}
	public class OperateDataPdr: CmpProvider<OperateData> { }
}
