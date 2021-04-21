using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class CombinedCubeUI : IComponent
	{
        public List<Entity> entities = new List<Entity>();
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
