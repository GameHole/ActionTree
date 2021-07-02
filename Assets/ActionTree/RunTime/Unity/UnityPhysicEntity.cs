using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityPhysicEntity : UnityEntity
    {
        public override bool alwaysRun => true;
        protected override void Join()
        {
            if (tree != null)
            {
                tree.Foreach((ref ITree v) =>
                {
                    if (v is ATree tree)
                        tree.driver = Mgr.driver;
                });
                Mgr.driver.RepleaseFindedTree(ref tree, null, Random.Range(0, Mgr.driver.Workers.Length), 0);
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
                    try
                    {
                        tree.Do();
                    }
                    catch (System.Exception e)
                    {
                        throw new System.Exception(tree.stack(), e);
                    }
                    
                }
            }
        }
    }
}

