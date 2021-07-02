using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    class EntityCntr
    {
        class ES
        {
            public HashSet<Type> eTypes = new HashSet<Type>();
            public Dictionary<uint, Entity> values = new Dictionary<uint, Entity>();
        }
        Dictionary<int, ES> entities = new Dictionary<int, ES>();
        public void Add(Entity entity)
        {
            int cmpHash = entity.GetCmpHash();
            
            if (!entities.TryGetValue(cmpHash, out var es))
            {
                es = new ES();
                foreach (var item in entity.components.Keys)
                {
                    es.eTypes.Add(item);
                }
                entities.Add(cmpHash, es);
            }
            es.values.Add(entity.id, entity);

            //Debug.Log($"e {entity},hash:{cmpHash} c::{ es.values.Count}");
            //string a = "";
            //foreach (var item in entity.components.Keys)
            //{
            //    a += item.ToString() + ",";
            //}
            //Debug.Log($"Add e {cmpHash} {entity.id} {a}");

        }
        public void Remove(Entity entity)
        {
            bool a = false;
            if (entities.TryGetValue(entity.GetCmpHash(), out var es))
            {
                 a = es.values.Remove(entity.id);
            }
            //Debug.Log($"real remaove hash {entity.GetCmpHash()} id {entity.id} {a }");
        }
        public IList<Entity> Find(params Type[] types)
        {
            List<Entity> re = new List<Entity>();
            foreach (var item in entities)
            {
                if (Contain(item.Value.eTypes, types))
                {
                  
                    re.AddRange(item.Value.values.Values);
                    //Debug.Log($"finded hash::{item.Key} cou:: {item.Value.values.Count}");
                }
            }
            return re;
        }
        bool Contain(HashSet<Type> esType, Type[] reqTypes)
        {
            for (int i = 0; i < reqTypes.Length; i++)
            {
                if (!esType.Contains(reqTypes[i]))
                    return false;
            }
            return true;
        }
        public void Clear()
        {
            foreach (var item in entities.Values)
            {
                item.eTypes.Clear();
                item.values.Clear();
            }
            entities.Clear();
        }
    }
}

