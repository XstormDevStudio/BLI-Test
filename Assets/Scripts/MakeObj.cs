using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
public enum ObjTypeToCreate
{
    cube,
    sphere
}

public enum PlayMoods
{
    create,
    drag,
    edit,
    rotate
}

public class MakeObj : MonoBehaviour //This script named as player handeller...!
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject editMode;//obj color palat
    public Transform currentSelectedObj;

    public static ObjTypeToCreate currentObj;
    public static PlayMoods playerStat;
    private bool toggleRotateMode;
    [SerializeField] private GameObject selectionObj;


    public List<ObjectData> savedObjs = new();


    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PlaceObjects();
        }
        if (currentSelectedObj != null && Input.GetKey(KeyCode.Delete))
        {
            Destroy(currentSelectedObj.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.R))
            ToogleMood();
    }

    private void PlaceObjects()
    {
        RaycastHit hitInfo;
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);


        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            if (hitInfo.transform.gameObject.tag == "Ground" && playerStat != PlayMoods.rotate)
            {
                playerStat = PlayMoods.create;

                if (currentObj == ObjTypeToCreate.cube)
                {
                    Instantiate(_cube, hitInfo.point, Quaternion.identity);
                }
                else if (currentObj == ObjTypeToCreate.sphere)
                {
                    Instantiate(_sphere, hitInfo.point, Quaternion.identity);
                }
                else
                {
                    Debug.LogError("Something not okay");
                }
            }
            if (hitInfo.transform.gameObject.tag == "obj" && playerStat != PlayMoods.rotate)
            {
                playerStat = PlayMoods.drag;
                currentSelectedObj = hitInfo.transform;
            }
        }
    }

    public void OnChangingMatColor()
    {
        if (playerStat == PlayMoods.drag)
        {
            Color selectColor = UnityEngine.Random.ColorHSV();
            currentSelectedObj.GetComponent<MeshRenderer>().material.color = selectColor;
        }
    }

    private void ToogleMood()
    {
        bool isTogg = toggleRotateMode;
        toggleRotateMode = !isTogg;

        if (isTogg) playerStat = PlayMoods.rotate;
        else playerStat = PlayMoods.drag;
    }

}
