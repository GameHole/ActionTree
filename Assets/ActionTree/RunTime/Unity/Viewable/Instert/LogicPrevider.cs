using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class LogicPrevider : TreeProvider
    {
        public Logic prefab;
        [HideInInspector] public Logic logic;

        public override ITree tree => logic.pdr.tree;

        public override ITree GetTree()=> logic.pdr.GetTree();

        internal override ITree Clone() => logic.pdr.Clone();

        internal override Type TreeType() => null;
        public override Entity MakeEntity(Entity parent)
        {
            var e = base.MakeEntity(parent);
            return logic.pdr.MakeEntity(e);
        }
        public override void CollectComponent()
        {
            var pdr = logic.pdr;
            pdr.CollectComponent();
            var cmps = GetComponents<CmpProvider>();
            for (int i = 0; i < cmps.Length; i++)
            {
                pdr.tempEntity.Add(cmps[i].GetValue());
            }
        }
        private void Awake()
        {
            //Debug.Log($"awake {this}");
            if (logic == null)
            {
                logic = Instantiate(prefab, transform);
            }
            foreach (var item in GetComponentsInChildren<TreeInserter>())
            {
                item.InjectLogic(logic);
            } 
        }
    }
}

