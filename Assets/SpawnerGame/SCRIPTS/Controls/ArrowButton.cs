using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowButton : Control, IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
{

    [SerializeField] Control parentControl;
    [SerializeField] int side;

    public void OnPointerDown(PointerEventData eventData)
    {
        parentControl.forse = side;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerDown(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerUp(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        parentControl.forse = 0;
    }

   
}
