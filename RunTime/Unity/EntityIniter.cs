using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public abstract class EntityIniter : MonoBehaviour, IEntityIniter
    {
        public void Init(UnityEntity entity)
        {
            entity.entity = new Entity();
            entity.entity.Add(entity);
            AddCmp(entity.entity);
            entity.entity.SetTree(MainTree());
            //entity.entity.AddMainTree(WorkTree());
        }
        protected abstract void AddCmp(Entity entity);
        protected abstract ITree MainTree();
        //protected virtual ITree WorkTree() => null;
    }
}

