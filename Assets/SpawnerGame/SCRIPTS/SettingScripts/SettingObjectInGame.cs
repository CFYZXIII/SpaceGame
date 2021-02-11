using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingObjectInGame : MonoBehaviour, ISaveable
{
    // Start is called before the first frame update
    SaveData data = new SaveData();

    [SerializeField] SettingObjectInGame parent;

   [SerializeField] Vector3 lastpos;
    [SerializeField] bool ingame;

    public new Image image;

    private void Awake()
    {
       
        lastpos = transform.position;
        if (ingame)         
        Load();
    }
 

    public void SaveData(SaveData data)
    {
        data.r = image.color.r;
        data.g = image.color.g;
        data.b = image.color.b;
        if (parent == null)
        {
            data.x = transform.position.x;
            data.y = transform.position.y;
        }
          

    }

    public void LoadData(SaveData data)
    {
        
        image.color = new Color(data.r, data.g, data.b, 1);
        if (parent == null)
            transform.position = new Vector3(data.x, data.y, transform.position.z);
          
    }

    public void Save()
    {
        SaveLoadSystem.SaveData(this);
    }

    public void Load()
    {
        SaveLoadSystem.LoadData(this);
    }

    public string getName()
    {
       
        if (parent != null)
        {
            return this.name + parent.getName();
        }
        return this.name + ".fun";
    }

    public void moveHorizontal(float ds)
    {
        lastpos = transform.position;
        if (parent != null)
            parent.moveHorizontal(ds);
        else
            transform.position += new Vector3(ds, 0, 0);
    }

    public void moveVertical(float ds)
    {
        lastpos = transform.position;
        if (parent != null)
            parent.moveVertical(ds);
        else
            transform.position += new Vector3(0, ds, 0);
    }



    public void MoveUndo() 
    {
        if (parent != null)
            parent.MoveUndo();
        else
            transform.position = lastpos;

    }


   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveUndo();
    }

}
