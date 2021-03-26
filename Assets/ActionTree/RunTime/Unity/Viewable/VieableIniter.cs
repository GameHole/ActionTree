using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class VieableIniter : MonoBehaviour, IEntityIniter
    {
        public void Init(UnityEntity unityEntity)
        {
            var tree = GetComponent<TreeProvider>();
            //if (tree)
            //{
            //    unityEntity.entity = new Entity();
            //    unityEntity.entity.Add(unityEntity);
            //    foreach (var item in GetComponents<CmpProvider>())
            //    {
            //        var m = item.GetValue();
            //        unityEntity.entity.Add(m);
            //    }
            //    unityEntity.entity.SetTree(tree.GetTree());
            //    Destroy(this);
            //}
            if (tree)
            {
                unityEntity.tree = tree.GetTree();
                unityEntity.tree?.Apply();
            }
        }
    }
}

