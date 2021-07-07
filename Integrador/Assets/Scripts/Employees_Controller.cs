using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employees_Controller : MonoBehaviour
{
    public static int cant_Nurse = 0;
    public static int max_Nurse = 3;
    public static float startTime;

    public Text txt_nurseInfo;
    void Start()
    {
        txt_nurseInfo.text = "";
        startTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        SetTime();
        NurseInfo();
    }

    public void SetTime()
    {
        if (cant_Nurse == 0)
        {
            startTime = 5f;
        }
        else if (cant_Nurse == 1)
        {
            startTime = 3f;
        }
        else if (cant_Nurse == 2)
        {
            startTime = 1.5f;
        }
    }

    public void NurseInfo()
    {
        txt_nurseInfo.text = cant_Nurse + "/" + max_Nurse;
    }
}
