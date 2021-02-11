using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector3 startPos;
    public float alpha;
    public int spirale;
    public float radius = 0f;
    [SerializeField] GameObject effect;
    
    public SpriteRenderer renderer;
    public bool evade;
 
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        
    }
    private void Start()
    {
        
        startPos = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        alpha += Time.deltaTime * spirale;
        radius += Time.deltaTime;
        transform.position = startPos + new Vector3(radius * Mathf.Cos(alpha), radius * Mathf.Sin(alpha), 0);
        transform.Rotate(0,0,2);
        if (transform.localScale.x < 1) 
        {
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f)*Time.deltaTime; 
        }
    }


    private void OnTriggerExit(Collider other)
    {      if (other.gameObject.GetComponent<DropSpawner>()!=null )
        {
            MyEvent e = new MyEvent();
            if (!evade)
                e.fail = -1;
                 
            ivent?.Invoke(this, e);
            
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.GetComponent<Player>() != null)
        {
            MyEvent e = new MyEvent();
            if (evade)
                e.fail = -1;
            ivent?.Invoke(this, e);          
        }
    }
    
    public event Ontriggered ivent;
    public delegate void Ontriggered(object sender, MyEvent e);

    public void Acrtivate() 
    {
        effect.SetActive(true);
    }




}
