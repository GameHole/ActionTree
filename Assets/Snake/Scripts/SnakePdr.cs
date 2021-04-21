using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Snake : IComponent
	{
        public List<Entity> bodys = new List<Entity>();
        public Entity Head
        {
            get
            {
                if (bodys.Count > 0)
                {
                    return bodys[0];
                }
                return null;
            }
        }
        public Entity Tail
        {
            get
            {
                if (bodys.Count > 0)
                {
                    return bodys[bodys.Count - 1];
                }
                return null;
            }
        }
    }
	public class SnakePdr: CmpProvider<Snake> { }
}
