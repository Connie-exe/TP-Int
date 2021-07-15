using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COVID_Counter : MonoBehaviour
{
    //private List<GameObject> sick_patients = new List<GameObject>();
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
        //GameObject s = GameObject.FindWithTag("COVID_Patient");
        //sick_patients.Add(s);
        txt_cont.text = "SickCount: " + cont;
    }
}
