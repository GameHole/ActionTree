using System;
namespace ActionTree
{
    public static partial class DriverEx
    {
        public static void Foreach<T>(this Driver driver, Func<T, bool> action) where T : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T));
            for (int i = 0; i < es.Count; i++)
            {
                if (action.Invoke(es[i].Get<T>()))
                {
                    break;
                }
            }
        }
        public static void Foreach<T0, T1>(this Driver driver, Func<T0, T1, bool> action) where T0 : class, IComponent where T1 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1));
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                if (action.Invoke(e.Get<T0>(), e.Get<T1>()))
                {
                    break;
                }
            }
        }
        public static void Foreach<T0, T1, T2>(this Driver driver, Func<T0, T1, T2, bool> action)
            where T0 : class, IComponent
            where T1 : class, IComponent
            where T2 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1), typeof(T2));
            //Debug.Log(es.Count);
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                if (action.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>()))
                {
                    break;
                }
            }
        }
        public static void Foreach<T0, T1, T2, T3>(this Driver driver, Func<T0, T1, T2, T3, bool> action)
         where T0 : class, IComponent
         where T1 : class, IComponent
         where T2 : class, IComponent
         where T3 : class, IComponent
        {
            var es = driver.FindEntitysWith(typeof(T0), typeof(T1), typeof(T2), typeof(T3));
            for (int i = 0; i < es.Count; i++)
            {
                var e = es[i];
                if (action.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>(), e.Get<T3>()))
                {
                    break;
                }
            }
        }
        public static void Foreach<T0, T1, T2, T3, T4>(this Driver driver, Func<T0, T1, T2, T3, T4, bool> action)
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
                if (action.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>(), e.Get<T3>(), e.Get<T4>()))
                {
                    break;
                }
            }
        }
        public static void Foreach<T0, T1, T2, T3, T4, T5>(this Driver driver, Func<T0, T1, T2, T3, T4, T5, bool> action)
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
                if (action.Invoke(e.Get<T0>(), e.Get<T1>(), e.Get<T2>(), e.Get<T3>(), e.Get<T4>(), e.Get<T5>()))
                {
                    break;
                }
            }
        }
    }
}
