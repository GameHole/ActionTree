using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class CombinedCubeUI : IComponent
	{
        public List<ETree> entities = new List<ETree>();
        public CombinedCube data;
        Vector3Int off;
        public Vector3Int Offset
        {
            get => off;
            set
            {
                off = value;
                for (int i = 0; i < entities.Count; i++)
                {
                    entities[i].Get<Offset>().value = off;
                }
            }
        }
        public void SetEnable(bool e)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Get<Enable>().value = e;
            }
        }
    }
}
