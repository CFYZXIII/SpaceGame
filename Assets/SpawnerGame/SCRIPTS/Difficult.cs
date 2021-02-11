using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficult : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> objects;
    GameObject current;
    public void SetObj(int i)
    {
        objects[i].SetActive(true);
        current = objects[i];
    }

    public void ResetObj() 
    {
        current?.SetActive(false);
    }
        
}
