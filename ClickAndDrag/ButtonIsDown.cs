using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonIsDown : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool IsDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("dowen");
        IsDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("upp");
        IsDown = false;
    }
}
