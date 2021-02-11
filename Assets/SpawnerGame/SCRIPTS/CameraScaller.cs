using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraScaller : MonoBehaviour
{
    // Start is called before the first frame update


   
    void Start()
    {
        

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float myRatio = 19.20f / 10.80f;

        if (screenRatio >= myRatio)
        {
            Camera.main.orthographicSize = 5;
        }
        else
        {
            float different = myRatio / screenRatio;
            Camera.main.orthographicSize = 5 * different;
        }
        

       
    }

    public void SetScene(int i) 
    {
        SceneManager.LoadScene(i);
    }

    public void Quit()
    {
        Debug.Log(111);
        Application.Quit();
    }

}
