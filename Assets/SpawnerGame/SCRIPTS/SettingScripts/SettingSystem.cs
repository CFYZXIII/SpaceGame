using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSystem : MonoBehaviour
{
    [SerializeField] List<SettingObject> settingObjects;

    private Image image;
    private SettingObject settingObject;
    private GameObject editeObject = null;
    // Start is called before the first frame update

    [SerializeField] ColorPicker2 colorPicker;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject def;
    [SerializeField] GameObject yes;
    Vector3 panelPos;

    public static bool byDefault;

   

    
    private void Awake()
    {
        panelPos = panel.transform.position;
        foreach (SettingObject s in settingObjects)
        {
            s.edit += S_edit;
            if (byDefault)
                s.Save();
            else
            s.Load();
        }
        byDefault = false;
    }

    public void Save()    
    {
        if (settingObject != null)
            settingObject.Save();
    }
    

    private void S_edit(object sender, MyEvent e)
    {
        if (editeObject != null)
            editeObject.SetActive(false);
        SetButtonsFalse();
        settingObject = sender as SettingObject;
        image = e.image;
        editeObject = e.editeObject;
        editeObject.SetActive(true);

        colorPicker.SettingImage = image;
        panel.SetActive(true);
        
        if (settingObjects.IndexOf(settingObject) >= settingObjects.Count/2)
            panel.transform.position = new Vector3(-panelPos.x, panelPos.y, panelPos.z);
        else
            panel.transform.position = new Vector3(panelPos.x, panelPos.y, panelPos.z);

    }

    private void OnDestroy()
    {
        foreach (SettingObject s in settingObjects)
            s.edit -= S_edit;
    }

    public void MoveObjectHorizontal(float ds) 
    {
        if (settingObject != null)
            settingObject.moveHorizontal(ds);
    }

    public void MoveObjectVertical(float ds)
    {
        if (settingObject != null)
            settingObject.moveVertical(ds);
    }

    public void SaveAll() 
    {
        foreach (SettingObject s in settingObjects)
            s.Save();
    }


    public void ByDefault() 
    {
        byDefault = true;
    }

    public void SetButtonsFalse()
    {
        def.SetActive(false);
        yes.SetActive(false);
    }

    public void EndEdite() 
    {
        editeObject?.SetActive(false);
    }
}
