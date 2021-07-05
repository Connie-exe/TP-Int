using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station_Controller : MonoBehaviour
{
    public static bool setTimer;
    void Start()
    {        
        setTimer = false;
    }
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Patient"))
        {
            transform.gameObject.tag = "Occupied";
            setTimer = true;
        }
    }

    public void OnTriggerExit(Collider collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Patient"))
        {
            transform.gameObject.tag = "Available";
        }
    }
    
}
