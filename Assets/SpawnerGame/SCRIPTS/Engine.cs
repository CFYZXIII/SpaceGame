using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] List<GameObject> Engines;




    public void StartEngine(int n) 
    {
        for (int i = 0; i < Engines.Count; i++)
        {
            if (i == n)
                Engines[i].SetActive(true);
            else
                Engines[i].SetActive(false);
        }
    }

    public void ResetEngine()
    {
        for (int i = 0; i < Engines.Count; i++)
        {
            
                Engines[i].SetActive(false);
        }
    }

}
