using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DropSpawner : MonoBehaviour
{


    public Drop dropPrefab;
    Queue<Drop> dropPool;

    public bool evade;
    public int spirale;
    public int spawnCount;

    public List<Sprite> sprites;
    public Player p;
    public int inverse = 1;
    public bool isspawn = true;

   

    void Start()
    {
        dropPool = new Queue<Drop>();
        for (int i = 0; i < spawnCount; i++)
        {
            Drop clone = Instantiate(dropPrefab);                     
            clone.transform.SetParent(transform, false);
            clone.gameObject.SetActive(false);
            clone.ivent += clone_Ontriggered;
            dropPool.Enqueue(clone);
        }
        
    }

    void clone_Ontriggered(object sender, MyEvent e) 
    {
        if(e.fail == -1)
            Event?.Invoke(this, e);
        Drop drop = sender as Drop;
        drop.radius = 0;
        drop.transform.position = drop.startPos;
        dropPool.Enqueue(drop);
        drop.gameObject.SetActive(false);
        if (dropPool.Count == spawnCount)
            isspawn = true;
    }
    
    

    public void spawn()
    {
        Drop drop = null;
        
        if (evade)
        {

            if (dropPool.Count == spawnCount)
            {
              spirale = spirale * (int)Mathf.Pow(-1, UnityEngine.Random.Range(0, 2));
                for (int i = 0; i < spawnCount; i++)
                {
                    drop = dropPool.Dequeue();
                    drop.transform.localScale = new Vector3( 0.2f, 0.2f, 0.2f);
                    drop.evade = evade;
                    drop.renderer.sprite = sprites[0];
                    drop.gameObject.SetActive(true);
                    drop.alpha = i * 2 * Mathf.PI / spawnCount + p.alpha * Mathf.PI / 180 - Mathf.PI / 2;

                    drop.spirale = spirale;
                    p.inverse = inverse;
                }
            }
            


        }
        if (!evade)//else
        {
            
            if (dropPool.Count > spawnCount - 1)
            {
               
                p.inverse = inverse;
                drop = dropPool.Dequeue();
                drop.evade = evade;
                drop.renderer.sprite = null;
                drop.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                drop.Acrtivate();
                drop.gameObject.SetActive(true);
                float beta = UnityEngine.Random.Range(-1.7f, 1.7f);
                drop.alpha = p.alpha * Mathf.PI / 180 + Mathf.PI / 2 + beta;
                drop.spirale = spirale * (int)Mathf.Pow(-1, UnityEngine.Random.Range(0, 2)); ;
            }
           
        }
        isspawn = false;
    }




    public event OnHelthReduced Event;
    public delegate void OnHelthReduced(object sender, MyEvent e);


    private void OnDestroy()
    {
        foreach(Drop d in dropPool)
            d.ivent -= clone_Ontriggered;
    }
}


