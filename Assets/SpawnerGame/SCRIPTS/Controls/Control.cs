using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    [SerializeField] private Control left;
    [SerializeField] private Control right;
  
    public int forse = 0;
    public int locked = 0;
    public bool TotalSwap = false;
    public bool SideSwap = false;
    Vector3 strPos;
    private void Awake()
    {
        strPos = transform.position;
    }



    public bool Swap(Control g2)
   {
      locked = 0;
       g2.locked = 0;
       transform.position = Vector3.MoveTowards(transform.position, g2.strPos, 0.2f);
       g2.transform.position = Vector3.MoveTowards(g2.transform.position, strPos, 0.2f);
           if ((transform.position - g2.strPos).magnitude == 0)
           {
               strPos = transform.position;
               g2.strPos = g2.transform.position;

            if (left != null)
            {
                left.strPos = left.transform.position;
                right.strPos = right.transform.position;
                g2.left.strPos = g2.left.transform.position;
                g2.right.strPos = g2.right.transform.position;
            }

           locked = 0;
           g2.locked = 0;
            return false;
           }

        return true;
   }


    public bool SpabButtons() 
    {
        return left.Swap(right);
    }

    private void FixedUpdate()
    {
        if (SideSwap)
            SideSwap = left.Swap(right);
    }

}
