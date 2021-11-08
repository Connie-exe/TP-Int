using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stations_Controller : MonoBehaviour
{
    private void Awake()
    {
        MakeAvailable();
    }
    private void MakeAvailable()
    {
        this.transform.tag = "Available";
    }
}
