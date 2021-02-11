using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image colorImage;
    [SerializeField] Image cross;
    public Image SettingImage;
    int X=512, Y=512;
    public void setColorX(float x, int px) 
    {
        X = px;
        cross.rectTransform.localPosition = new Vector2(x, cross.rectTransform.localPosition.y);
        if(SettingImage != null)
        SettingImage.color = (colorImage.mainTexture as Texture2D).GetPixel(X, Y);
      
    }

    public void setColorY(float y, int py)
    {
        Y = py;
        cross.rectTransform.localPosition = new Vector2( cross.rectTransform.localPosition.x,y);
        if(SettingImage!=null)
        SettingImage.color = (colorImage.mainTexture as Texture2D).GetPixel(X, Y);
       
    }

    
}
