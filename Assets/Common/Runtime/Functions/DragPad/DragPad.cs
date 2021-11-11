using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
    public class DragPad : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
    {
        public Action<PointerEventData> onBeginDrag;
        public Action<PointerEventData> onDrag;
        public Action<PointerEventData> onEndDrag;
        public Action<PointerEventData> onPointerDown;
        public Action<PointerEventData> onPointerUp;
        public PointerEventData beginDragEventData;
        public PointerEventData draggingEventData;
        public PointerEventData endDragEventData;
        public void OnBeginDrag(PointerEventData eventData)
        {
            beginDragEventData = eventData;
            onBeginDrag?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            draggingEventData = eventData;
            onDrag?.Invoke(eventData);
            //Debug.Log(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            endDragEventData = eventData;
            onEndDrag?.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onPointerDown?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUp?.Invoke(eventData);
        }

        //public void OnPointerDown(PointerEventData eventData)
        //{
        //    onEntry?.Invoke(eventData.position);
        //}

        //public void OnPointerUp(PointerEventData eventData)
        //{
        //    onExit?.Invoke(eventData.position);
        //}
    }
}

