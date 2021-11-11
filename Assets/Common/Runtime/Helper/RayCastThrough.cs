using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ActionTree
{
    public static class RayCastThrough 
    {
        public static List<GameObject> ThroughAndExecute<T>(PointerEventData baseData, ExecuteEvents.EventFunction<T> eventFunction) where T : IEventSystemHandler
        {
            List<RaycastResult> results = new List<RaycastResult>();
            List<GameObject> exes = new List<GameObject>();
            GameObject currObj = baseData.pointerCurrentRaycast.gameObject ?? baseData.pointerDrag;
            EventSystem.current.RaycastAll(baseData, results);
            //GameObject currObj = baseData.pointerCurrentRaycast.gameObject ?? baseData.pointerDrag;
            foreach (var item in results)
            {
                var next = item.gameObject;
                if (next != null && next != currObj)
                {
                    var exe = ExecuteEvents.GetEventHandler<T>(next);
                    if (exe != currObj)
                    {
                        ExecuteEvents.Execute(exe, baseData, eventFunction);
                        exes.Add(exe);
                    }
                }
            }
            return exes;
        }
        public static List<GameObject> ThroughAndExecute<T>(this IEventSystemHandler mono, PointerEventData baseData, ExecuteEvents.EventFunction<T> eventFunction) where T : IEventSystemHandler
        {
           return ThroughAndExecute(baseData, eventFunction);
        }
        public static void Execute<T>(PointerEventData baseData, ExecuteEvents.EventFunction<T> eventFunction, List<GameObject> results) where T : IEventSystemHandler
        {
            foreach (var item in results)
            {
                ExecuteEvents.Execute(item, baseData, eventFunction);
            }
        }
        public static void Execute<T>(this IEventSystemHandler mono,PointerEventData baseData, ExecuteEvents.EventFunction<T> eventFunction, List<GameObject> results) where T : IEventSystemHandler
        {
            Execute(baseData, eventFunction, results);
        }
    }
}

