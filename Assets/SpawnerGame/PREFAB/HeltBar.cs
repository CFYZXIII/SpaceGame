using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeltBar : MonoBehaviour
{
    public List<GameObject> objects;

    float s = 2;
    float dt = 0;
    float startTime = 0;
    public void HealthReduse() 
    {
        if (objects.Count > 0)
        {
            GameObject current = objects[objects.Count - 1];
            current.SetActive(false);
            objects.Remove(current);
        }
        
    }

    

    private void FixedUpdate()
    {
        startTime += Time.deltaTime;
        if (startTime > 3)
        {
            dt += Time.deltaTime;
            if (dt >= 3)
            {
                s *= -1;
                dt = 0;
            }
            transform.Rotate(0, 0, s);
        }
    }

    public void Activate() 
    {
        gameObject.SetActive(true);
        foreach (GameObject g in objects)
            g.SetActive(true);
    }

}
