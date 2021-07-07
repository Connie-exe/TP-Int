using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text txt_notif;
    public static bool b_covid_notif;
    public GameObject covid_patient;
    //public GameObject arrow;
    //private float offsetX;
    //private bool b_isCreated;
    void Start()
    {
        txt_notif.text = "";
        b_covid_notif = false;
        //b_isCreated = false;
        covid_patient = GameObject.FindGameObjectWithTag("COVID_Patient");
    }

    
    void LateUpdate()
    {
        CovidNotif();
        //ArrowPoint();
    }

    public void CovidNotif()
    {
        covid_patient = GameObject.FindGameObjectWithTag("COVID_Patient");
        if (covid_patient == true && b_covid_notif == false)
        {
            txt_notif.text = "Oh no! This patient has COVID. Click on them to send them home or they're gonna spread the disease.";
            b_covid_notif = true;
            //ArrowPoint();
            //StartCoroutine(COVID_Instruction());
        }
        if(covid_patient == false)
        {
            txt_notif.text = "";
        }
    }

    //IEnumerator COVID_Instruction()
    //{
    //    yield return new WaitForSeconds(3f);
    //    txt_notif.text = "";
    //}

    //public void ArrowPoint()
    //{
    //    if(b_isCreated == false)
    //    {
    //        offsetX = covid_patient.transform.position.x;
    //        Vector3 transform = new Vector3(offsetX, covid_patient.transform.position.y + 2, covid_patient.transform.position.z);
    //        Instantiate(arrow, transform, Quaternion.identity);
    //        b_isCreated = true;
    //    }

    //}
}
