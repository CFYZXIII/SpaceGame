using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseControl : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Sprite first;
    [SerializeField] private Sprite second;
    Image image;
    int i = 0;
 

    public void OnPointerDown(PointerEventData eventData)
    {
        i++;
        if (i % 2 != 0)
        {
            image.sprite = second;
            Time.timeScale = 0;
        }
        else
        {
            image.sprite = first;
            Time.timeScale = 1;
        }
    }

    private void Start()
    {
        image = GetComponent<Image>();
    }
}
