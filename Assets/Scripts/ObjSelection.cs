using System.Collections.Generic;
using UnityEngine;

public class ObjSelection : MonoBehaviour
{
    public void OnClickCube()
    {
        MakeObj.currentObj = ObjTypeToCreate.cube;
    }
    public void OnClickSphere()
    {
        MakeObj.currentObj = ObjTypeToCreate.sphere;
    }
}
