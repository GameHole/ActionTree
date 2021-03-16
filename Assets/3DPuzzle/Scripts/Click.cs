using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Default
{
    public class Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool isDown;
        public bool isUp;
        public void OnPointerDown(PointerEventData eventData)
        {
            isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isUp = true;
        }
        //private void LateUpdate()
        //{
        //    Debug.Log("click");
        //    isDown = isUp = false;
        //}
    }
}

