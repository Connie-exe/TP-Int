using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeableObjectPrefabs;

    private int currentPrefabIndex = -1;

    private GameObject currentPlaceableObject;

    //private float mouseWheelRotation;

    private void Update()
    {
        HandleNewObjectKey();
        if(currentPlaceableObject != null)
        {
            MoveCurrentObjectMouse();
            //RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void HandleNewObjectKey()
    {
        for (int i = 0; i < placeableObjectPrefabs.Length; i++)
        {         
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                if (PressedKeyCurrentPrefab(i))
                {
                    Destroy(currentPlaceableObject);
                    currentPrefabIndex = -1;
                }
                else
                {
                    if (currentPlaceableObject != null)
                    {
                        Destroy(currentPlaceableObject);
                    }

                    currentPlaceableObject = Instantiate(placeableObjectPrefabs[i]);
                    currentPrefabIndex = i;
                    //Patient_Controller.stations.Add(placeableObjectPrefabs[i]);
                }
                break;
            }
        }
    }

    private bool PressedKeyCurrentPrefab(int i)
    {
        return currentPlaceableObject != null && currentPrefabIndex == i;
    }

    private void MoveCurrentObjectMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;

        if(Physics.Raycast(ray,out hitinfo))
        {
            currentPlaceableObject.transform.position = hitinfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitinfo.normal);
        }
    }

    //private void RotateFromMouseWheel()
    //{
    //    mouseWheelRotation += Input.mouseScrollDelta.y;
    //    currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    //}

    private void ReleaseIfClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }
}
