using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointInImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    public bool isEnter;

    public void OnPointerDown(PointerEventData eventData)
    {
        isEnter = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //isEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //isEnter = false;
    }
}
