using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Target : IComponent
	{
        public Entity value;
        public bool isNull() => value == null;
        public T Get<T>() where T : class, IComponent => value == null ? null : value.Get<T>();
	}
	public class TargetPdr: CmpProvider<Target>
    {
        public UnityEntity entity;
        public override IComponent GetValue()
        {
            if (entity)
            {
                entity.InitOnce();
                value.value = entity.entity;
            }
            return base.GetValue();
        }
    }
}
