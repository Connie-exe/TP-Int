using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stations_Controller : MonoBehaviour
{
    private void Update()
    {
        MakeAvailable();
    }
    private void MakeAvailable()
    {
        this.transform.tag = "Available";
    }
}
