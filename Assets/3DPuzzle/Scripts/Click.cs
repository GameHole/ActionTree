using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ActionTree
{
    public class Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool isDown;
        public bool isUp;
        public void OnPointerDown(PointerEventData eventData)
        {
            isDown = true;
            Debug.Log("dwon");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("up");
            isUp = true;
        }
        //private void LateUpdate()
        //{
        //    Debug.Log("click");
        //    isDown = isUp = false;
        //}
    }
}

