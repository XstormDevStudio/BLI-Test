using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllingSelectedObj : MonoBehaviour
{
    [SerializeField] private Vector3 mousePos;
    public Vector3 thisObjSize;

    private void OnEnable()
    {
        thisObjSize = transform.localScale;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        if (PlayerController.playerStat == PlayMoods.dragOrEdit)
        {
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
            transform.position = new Vector3(c.x, transform.position.y, c.z);
        }

        if (PlayerController.playerStat == PlayMoods.rotate)
        {
            float turnX = Input.GetAxis("Mouse X") * 2f;
            float turnY = Input.GetAxis("Mouse Y") * 2f;
            transform.Rotate(Vector3.down,turnX);
            transform.Rotate(Vector3.right,turnY);
        }
    }

    private void Update()
    {
        if (thisObjSize.x != transform.localScale.x ||
            thisObjSize.y != transform.localScale.y ||
            thisObjSize.z != transform.localScale.z)
        {
            transform.localScale = thisObjSize;
        }
    }
}
