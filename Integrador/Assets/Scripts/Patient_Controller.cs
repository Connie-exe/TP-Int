using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Patient_Controller : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public static float fillTime;
    private NavMeshAgent patient;

    public List<GameObject> stations = new List<GameObject>();
    public GameObject _waitingRoom;
    public GameObject _exit;
    public int cont_station = 0;

    public float waitingRoomTime;
    public static bool b_vaccined;

    public Image fillimage;

    //public GameObject sick_patient;
    //public Transform sick_patientPos;

    void Start()
    {
        waitTime = Employees_Controller.startTime;       
        //fillTime = waitTime;
        patient = GetComponent<NavMeshAgent>();
        b_vaccined = true;
    }

    void Update()
    {
        //Contagious();       
        PatrolBehavior();
        WaitingRoom(); 
    }


    public void PatrolBehavior()
    {
        if ((stations[cont_station].tag == "Available" || Vector2.Distance(patient.transform.position, stations[cont_station].transform.position) < 0.4f) && stations[cont_station] != null)
        {
            patient.SetDestination(stations[cont_station].transform.position);
            if (Vector2.Distance(patient.transform.position, stations[cont_station].transform.position) < 0.4f)
            {
                if (waitTime <= 0)
                {
                    stations[cont_station].transform.tag = "Available";
                    cont_station++;
                    waitTime = Employees_Controller.startTime;                                
                }
                else
                {
                    stations[cont_station].transform.tag = "Occupied";
                    StationTime.b_occupied = true;
                    waitTime -= Time.deltaTime;
                    fillimage.fillAmount = waitTime / Employees_Controller.startTime;
                }
            }
        }

    }

    public void WaitingRoom()
    {
        if (stations[cont_station].tag == "Occupied" && Vector2.Distance(patient.transform.position, stations[cont_station].transform.position) > 0.4f && waitingRoomTime > 0)
        {
            patient.SetDestination(_waitingRoom.transform.position);
            waitingRoomTime -= Time.deltaTime;
            //fillimage.fillAmount = waitTime / Employees_Controller.startTime;
        }
        if(waitingRoomTime <= 0)
        {
            patient.SetDestination(_exit.transform.position);
            b_vaccined = false;
        }
    }

    //public void Contagious()
    //{
    //    if (Vector3.Distance(transform.position, sick_patientPos.position) < 3f )
    //    {
    //        Instantiate(sick_patient, transform.position, transform.rotation);
    //        Destroy(this.gameObject);
    //        //StartCoroutine(Contagiar());
    //    }
    //}

    //IEnumerator Contagiar()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Instantiate(sick_patient, this.transform.position, this.transform.rotation);
    //    Destroy(this.gameObject);
    //}

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dirt"))
        {
            speed -= 4;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dirt"))
        {
            speed += 4;
        }
    }
}
