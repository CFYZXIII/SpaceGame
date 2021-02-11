using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class VolumeButton : MonoBehaviour
{
    [SerializeField] UnityEvent myEvene;
    Material material;
    bool isDisolving;
    float fade = 1f;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void OnMouseDown()
    {
        myEvene?.Invoke();
    }

   

    public void Test() 
    {
        Debug.Log("dsds");
        isDisolving = true;
    }

    private void FixedUpdate()
    {
        if (isDisolving)
            Debug.Log(1);
        
    }

    private void Update()
    {
      
       if (isDisolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDisolving = false;
            }
            material.SetFloat("fade", fade);

        }
    }

    public void LoadScene(int index)
    {
        isDisolving = true;
        StartCoroutine(AsyncLoad(index));
        //StartCoroutine(AsyncLoad(index));
    }

    IEnumerator AsyncLoad(int index) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = true;
        while (!operation.isDone)
        {
           
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            isDisolving = true;
            
           // Debug.Log(progress);
            yield return 0.1f;
        }
    }
}
