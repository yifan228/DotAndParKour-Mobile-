using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonIsDown : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    private void Start()
    {
        if (gameObject.name == "groundJump") JustClick = true;
    }
    public bool IsDown = false;
    [SerializeField] bool JustClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!JustClick) return;
        Debug.Log("IsD");
        IsDown = true;
        Invoke("SetIsDownF", 0.03f);
    }
    void SetIsDownF()
    {
        IsDown = false;
        Debug.Log("IsDownF");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (JustClick) return;
        Debug.Log("dowen");
        IsDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (JustClick) return;
        Debug.Log("upp");
        IsDown = false;
    }
}
