using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom : MonoBehaviour
{
    public MeshRenderer _waitingRoomTint;

    void Update()
    {
        Checking();
    }

    public void Checking()
    {
        if(Store_Controller.b_waitingRoom == false)
        {
            _waitingRoomTint.enabled = false;
        }
        else
        {
            _waitingRoomTint.enabled = true;
        }
    }
}
