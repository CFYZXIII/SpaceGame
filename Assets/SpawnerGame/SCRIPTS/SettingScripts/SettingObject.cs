using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SettingObject : SettingObjectInGame, IPointerDownHandler
{
    // Start is called before the first frame update
    public event OnSelected edit;
    public delegate void OnSelected(object sender, MyEvent e);
    [SerializeField] GameObject editeObject;

   // private Image image;

    

    

    public void OnPointerDown(PointerEventData eventData)
    {
        MyEvent e = new MyEvent();
        e.image = image;
        e.editeObject = editeObject;
        edit?.Invoke(this,e);
    }

   
}
