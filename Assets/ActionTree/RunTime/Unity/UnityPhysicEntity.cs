using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityPhysicEntity : UnityEntity
    {
        protected override void Join()
        {
            if (tree != null)
            {
                tree.Foreach((ref ITree v) =>
                {
                    if (v is ATree tree)
                        tree.driver = Mgr.driver;
                });
            }
        }
        private void FixedUpdate()
        {
            if (tree != null)
            {
                if (tree.Condition)
                {
                    Destroy(gameObject);
                }
                else
                {
                    tree.Do();
                }
            }
        }
    }
}

