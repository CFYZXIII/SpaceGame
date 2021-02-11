using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Picker : MonoBehaviour, IDragHandler
{
    Vector2 inputDir = Vector2.zero;
    Vector2 finPos = Vector2.zero;
    [SerializeField] ColorPicker2 picker;
    [SerializeField] float ofset;
    [SerializeField] bool vertical;
    Image pickerImage;
    Image myImage;

    private void Awake()
    {
        pickerImage = picker.GetComponent<Image>();
        myImage = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        
        float bgSizeX = pickerImage.rectTransform.sizeDelta.x;
        float bgSizeY = pickerImage.rectTransform.sizeDelta.y;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(pickerImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {

            pos.x = pos.x > pickerImage.rectTransform.sizeDelta.x / 2 ? pickerImage.rectTransform.sizeDelta.x / 2 : pos.x;
            pos.x = pos.x < -pickerImage.rectTransform.sizeDelta.x / 2 ? -pickerImage.rectTransform.sizeDelta.x / 2 : pos.x;

            pos.y = pos.y > pickerImage.rectTransform.sizeDelta.x  / 2 ? pickerImage.rectTransform.sizeDelta.x / 2 : pos.y;
            pos.y = pos.y < -pickerImage.rectTransform.sizeDelta.x / 2 ? -pickerImage.rectTransform.sizeDelta.x / 2 : pos.y;

            if (vertical)
            {
                myImage.rectTransform.localPosition = new Vector2(myImage.rectTransform.localPosition.x, pos.y);
                
                //Debug.Log();
                Debug.Log("передаём y");
                picker.setColorY(pos.y, Mathf.RoundToInt(((pos.y + pickerImage.rectTransform.sizeDelta.x / 2) / pickerImage.rectTransform.sizeDelta.x) * 1024));
            }
            else
            {
                myImage.rectTransform.localPosition = new Vector2(pos.x, myImage.rectTransform.localPosition.y);
               // Debug.Log(  Mathf.RoundToInt(((pos.x+ pickerImage.rectTransform.sizeDelta.x/2)/ pickerImage.rectTransform.sizeDelta.x)*1024 )  );
               
                Debug.Log("передаём x");
                picker.setColorX(pos.x, Mathf.RoundToInt(((pos.x + pickerImage.rectTransform.sizeDelta.x / 2) / pickerImage.rectTransform.sizeDelta.x) * 1024));
            }

           
           
        }
    }  
}
