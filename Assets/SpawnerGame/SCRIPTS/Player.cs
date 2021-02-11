using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject center;
    [SerializeField] private Engine engine;
    public Control myControl;

    public float alpha = 0;   
    public int inverse = 1;
    public int speed;
    

   

    // Update is called once per frame
    void FixedUpdate()
    {
        alpha += Time.deltaTime * speed *  myControl.forse*myControl.locked;
        center.transform.eulerAngles = new Vector3(0, 0, alpha);

    }
}
