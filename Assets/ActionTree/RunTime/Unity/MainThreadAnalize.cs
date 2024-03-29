﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActionTree
{
    internal static class MainThreadAnalize
    {
        static Dictionary<Type,UpdateType> _isInMain = new Dictionary<Type, UpdateType>();
        static MainThreadAnalize()
        {
            foreach (var type in TreeInfo.GetTypes())
            {
                var main = type.GetCustomAttribute<MainThreadAttribute>();
                if (main != null)
                {
                    //UnityEngine.Debug.Log(type);
                    _isInMain.Add(type, main.update);
                }
                //else
                //{
                //    var info = kv.Value;
                //    if (ContainUnityObject(info.cmpFields)
                //     || ContainUnityObject(info.findedFields))
                //    {
                //        UnityEngine.Debug.Log(kv.Key);
                //        //_isInMain.Add(kv.Key, UpdateType.Update);
                //    }
                //}
            }
        }
        static bool ContainUnityObject(List<FieldInfo> infos)
        {
            foreach (var field in infos)
            {
                foreach (var item in field.FieldType.GetFields())
                {
                    if (item.FieldType.IsSubclassOf(typeof(UnityEngine.Component)))
                    {
                        return true;
                    }
                } 
            }
            return false;
        }
        public static bool IsInMain(Type type,out UpdateType update)
        {
            return _isInMain.TryGetValue(type, out update);
        }
    }
}
