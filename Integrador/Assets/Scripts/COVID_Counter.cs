using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COVID_Counter : MonoBehaviour
{

    public static int cont;
    public Text txt_cont;
    void Start()
    {
        txt_cont.text = "SickCount: ";
    }   
    void Update()
    {
        Count_Sick();
    }

    public void Count_Sick()
    {
        //sick_patients = GameObject.FindGameObjectsWithTag("COVID_Patient");
        //cont++;
        //txt_cont.text = "SickCount: " + cont;
    }
}
