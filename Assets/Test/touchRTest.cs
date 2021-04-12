using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class touchRTest : MonoBehaviour,IPointerDownHandler
{
    public RectTransform rect;
    public RectTransform minRect;
    public RectTransform maxRect;

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 size = Vector2.zero;
        Vector2 min = Vector2.zero;
        Vector2 max = Vector3.zero;
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            Debug.Log($"r = {touch.radius} min = {touch.radius - touch.radiusVariance} max = {touch.radius + touch.radiusVariance} , par = {touch.pressure}");
            size = Vector2.one * touch.radius;
            min = Vector2.one * (touch.radius - touch.radiusVariance);
            max = Vector2.one * (touch.radius + touch.radiusVariance);
        }
        rect.sizeDelta = size;
        minRect.sizeDelta = min;
        maxRect.sizeDelta = max;
    }
}
