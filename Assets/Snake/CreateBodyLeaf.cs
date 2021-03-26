﻿using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
	public sealed class CreateBody:ATree
	{
        Snake snake;
        Prefabs prefabs;
        Count count;
		public override void Do()
        {
            for (int i = 0; i < count.value; i++)
            {
                int id = 1;
                if (snake.Tail == null)
                    id = 0;
                var clone = Object.Instantiate(prefabs.prefabs[id]);
                var e = clone.GetComponent<UnityEntity>();
                e.InitOnce();
                if (snake.Tail != null)
                {
                    e.tree.Get<Target>().value = snake.Tail;
                }
                snake.bodys.Add(e.tree);
            }
            Condition = true;
        }
	}
	public class CreateBodyLeaf: TreeProvider<CreateBody> { }
}
