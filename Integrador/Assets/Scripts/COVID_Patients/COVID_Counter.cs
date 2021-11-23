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
        cont = 0;
        txt_cont.text = "0/4";
    }   
    void Update()
    {
        Count_Sick();
        //COVID_Destroy();
    }

    public void Count_Sick()
    {
        //GameObject s = GameObject.FindWithTag("COVID_Patient");
        //sick_patients.Add(s);
        txt_cont.text = "" + cont + "/4";
    }

    //public static void COVID_Destroy()
    //{
    //    GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("COVID_Patient");
    //    foreach (GameObject t in taggedObjects)
    //    {
    //        Destroy(t);
    //    }
    //}
}
