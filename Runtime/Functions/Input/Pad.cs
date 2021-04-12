using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
    public class Pad : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public Action<Vector2> onDown;
        public Action<Vector2> onUp;
        public void OnPointerDown(PointerEventData eventData)
        {
            onDown?.Invoke(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onUp?.Invoke(eventData.position);
        }
    }
}

