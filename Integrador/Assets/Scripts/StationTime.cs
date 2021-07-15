using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationTime : MonoBehaviour
{
    public Image fillImage;
    public static bool b_occupied;
    public GameObject patient;
    public GameObject station;

    private void Start()
    {
        b_occupied = false;
        fillImage = this.GetComponent<Image>();
    }
    void Update()
    {
       DuringTurn();
    }

    public void DuringTurn()
    {
        if(b_occupied == false)
        {
            fillImage.fillAmount = Employees_Controller.startTime;
            //Debug.Log("Restablece Tiempo");
        }
       if (b_occupied == true && Vector2.Distance(patient.transform.position, station.transform.position) < 0.4f)
        {
            
            fillImage.fillAmount = Patient_Controller.fillTime/ Employees_Controller.startTime;
            //Debug.Log("Quita tiempo");
        } 
 
    }
}
