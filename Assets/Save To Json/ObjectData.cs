using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public string x;
    public string y;
    public string z;

    public ObjectData(string x,string y,string z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

}
