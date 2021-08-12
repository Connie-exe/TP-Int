using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VIP_Patients : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (VIP_Controller.waitTime > 0)
        {
            VIP_Controller.b_isVIP = true;
            SceneManager.LoadScene("MiniGame");
        }
    }
}
