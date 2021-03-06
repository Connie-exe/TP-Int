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

    public static int cant_Publicist = 0;
    public static int max_Publicist = 2;
    public static float intantiator_timer;

    public static bool b_security = false;
    public static int cant_Security = 0;
    public static int max_Security = 1;

    public Text txt_nurseInfo;
    public Text txt_JanitorInfo;
    public Text txt_PublicistInfo;
    public Text txt_SecurityInfo;

    public GameObject[] janitor;
    public static bool b_add_janitor;
    public static int cont_janitor_active = -1;

    public GameObject security;
    void Start()
    { 
        txt_nurseInfo.text = "";
        txt_JanitorInfo.text = "";
        txt_PublicistInfo.text = "";
        txt_SecurityInfo.text = "";
        startTime = 5f;
        intantiator_timer = 7f;
        b_add_janitor = false;  
    }

    // Update is called once per frame
    void Update()
    {
        SetTime();
        SetTimeInstantiator();
        NurseInfo();
        JanitorInfo();
        PublicistInfo();
        SecurityInfo();
        ActiveJanitor();
        ActveSecurity();
    }

    public void SetTime()
    {
        //if(Protesta_Controller.b_protesta == false)
        //{
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
                startTime = 2f;
            }
            else if (cant_Nurse == 3)
            {
                startTime = 1.5f;
            }
        //}     
    }

    public void SetTimeInstantiator()
    {
        if (cant_Publicist == 0)
        {
            intantiator_timer = 7f;
        }
        else if (cant_Publicist == 1)
        {
            intantiator_timer = 5f;
        }
        else if (cant_Nurse == 2)
        {
            intantiator_timer = 3.5f;
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

    public void PublicistInfo()
    {
        txt_PublicistInfo.text = cant_Publicist + "/" + max_Publicist;
    }

    public void SecurityInfo()
    {
        txt_SecurityInfo.text = cant_Security + "/" + max_Security;  
    }

    public void ActiveJanitor()
    {
        if(b_add_janitor == true)
        {
            janitor[cont_janitor_active].SetActive(true);
        }
        b_add_janitor = false;
    }

    public void ActveSecurity()
    {
        if(b_security == true)
        {
            security.SetActive(true);
        }
    }
}
