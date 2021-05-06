using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
    public class Pad : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
    {
        public Action<PointerEventData> onDown;
        public Action<PointerEventData> onUp;
        public void OnPointerDown(PointerEventData eventData)
        {
            onDown?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //throw new NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onUp?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onUp?.Invoke(eventData);
        }
    }
}

