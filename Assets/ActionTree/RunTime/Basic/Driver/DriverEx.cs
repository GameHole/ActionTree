using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public static partial class DriverEx
    {
        public static void Foreach<T>(this Driver driver, Action<T> action) where T : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T));
            for (int i = 0; i < es.Count; i++)
            {
                action?.Invoke(es[i].Get<T>());
            }
        }
        
        public static void Foreach<T0, T1>(this Driver driver, Action<T0, T1> action) where T0 : class, IComponent where T1 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1));
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                action?.Invoke(e.Get<T0>(), e.Get<T1>());
            }
        }
        
        public static void Foreach<T0, T1, T2>(this Driver driver, Action<T0, T1, T2> action)
            where T0 : class, IComponent
            where T1 : class, IComponent
            where T2 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1), typeof(T2));
            //Debug.Log(es.Count);
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                action?.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>());
            }
        }
        
        public static void Foreach<T0, T1, T2, T3>(this Driver driver, Action<T0, T1, T2, T3> action)
         where T0 : class, IComponent
         where T1 : class, IComponent
         where T2 : class, IComponent
         where T3 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1), typeof(T2), typeof(T3));
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                action?.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>(), e.Get<T3>());
            }
        }
        
        public static void Foreach<T0, T1, T2, T3, T4>(this Driver driver, Action<T0, T1, T2, T3, T4> action)
            where T0 : class, IComponent
            where T1 : class, IComponent
            where T2 : class, IComponent
            where T3 : class, IComponent
            where T4 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4));
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                action?.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>(), e.Get<T3>(), e.Get<T4>());
            }
        }
        
        public static void Foreach<T0, T1, T2, T3, T4, T5>(this Driver driver, Action<T0, T1, T2, T3, T4, T5> action)
            where T0 : class, IComponent
            where T1 : class, IComponent
            where T2 : class, IComponent
            where T3 : class, IComponent
            where T4 : class, IComponent
            where T5 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                action?.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>(), e.Get<T3>(), e.Get<T4>(), e.Get<T5>());
            }
        }
        
    }
}

