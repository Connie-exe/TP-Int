using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employees_Controller : MonoBehaviour
{
    public static int cant_Nurse = 0;
    public static int max_Nurse = 3;
    public static float startTime;

    public static int cant_Janitor = 0;
    public static int max_Janitor = 3;

    public Text txt_nurseInfo;
    public Text txt_JanitorInfo;

    public GameObject[] janitor;
    public static bool b_add_janitor;
    public static int cont_janitor_active = 0;
    void Start()
    {
        txt_nurseInfo.text = "";
        txt_JanitorInfo.text = "";
        startTime = 5f;
        b_add_janitor = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTime();
        NurseInfo();
        JanitorInfo();
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

    public void JanitorInfo()
    {
        txt_JanitorInfo.text = cant_Janitor + "/" + max_Janitor;
    }

    public void ActiveJanitor()
    {
        if(b_add_janitor == true)
        {
            janitor[cont_janitor_active].SetActive(true);
        }
        b_add_janitor = false;
    }
}
