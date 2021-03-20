using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class Target : IComponent
	{
        public Entity value;
	}
	public class TargetPdr: CmpProvider<Target>
    {
        public UnityEntity entity;
        public override object GetValue()
        {
            if (entity)
                value.value = entity.entity;
            Debug.Log(value.value);
            return base.GetValue();
        }
    }
}
