using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataHandelar : MonoBehaviour
{

    private void OnEnable()
    {

        FindObjectOfType<MakeObj>().savedObjs.Add(new ObjectData(transform.position.x.ToString(),transform.position.y.ToString(),transform.position.z.ToString()));
    }

}
