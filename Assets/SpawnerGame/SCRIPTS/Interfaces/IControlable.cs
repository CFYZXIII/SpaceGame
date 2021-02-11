using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlable 
{
     void Lock(bool locked);
     void SetX(float x);
     float GetX();

    Vector3 getStrPos();
    void SetStrPos(Vector3 vector);

    Transform transform { get ; }

}
