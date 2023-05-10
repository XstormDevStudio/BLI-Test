using System.Collections.Generic;
using UnityEngine;

public class ObjSelection : MonoBehaviour
{
    public void OnClickCube()
    {
        PlayerController.currentObj = ObjTypeToCreate.cube;
    }
    public void OnClickSphere()
    {
        PlayerController.currentObj = ObjTypeToCreate.sphere;
    }
}
