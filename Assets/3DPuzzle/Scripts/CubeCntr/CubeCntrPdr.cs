using ActionTree;
using UnityEngine;
using System.Collections.Generic;
namespace Default
{
	[System.Serializable]
	public sealed class CubeCntr : IComponent
	{
        [HideInInspector] public bool[] array;
        public int size;
        [HideInInspector] public int size2;
        public bool this[Vector3Int pos]
        {
            get
            {
                return array[toIndex(pos)];
            }
            set
            {
                int idx = toIndex(pos);
                array[idx] = value;
            }
        }
        public int toIndex(Vector3Int pos)
        {
            return size2 * pos.x + size * pos.y + pos.z;
        }
        public Vector3Int devided(int idx)
        {
            int x = idx / size2;
            int last = idx % size2;
            int y = last / size;
            int z = last % size;
            return new Vector3Int(x, y, z);
        }
    }
	public class CubeCntrPdr: CmpProvider<CubeCntr> { }
}
