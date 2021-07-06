using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patient_Controller : MonoBehaviour
{
    //public List<GameObject> stations;
    //public GameObject waitingRoom;
    //private NavMeshAgent patient;
    //private GameObject next_station;
    //public static bool this_available;
    //public float timer;
    //public int cont_station = 0;
    //void Start()
    //{
    //    timer = 0;
    //    patient = GetComponent<NavMeshAgent>();
    //    this_available = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    AvailableStations();
    //    NextStation();
    //    SetTimer();
    //}

    //public GameObject AvailableStations()
    //{
    //    GameObject[] gos;
    //    //GameObject[] gos2;
    //    gos = GameObject.FindGameObjectsWithTag("Available");
    //    //gos2 = GameObject.FindGameObjectsWithTag("Occupied");
    //    next_station = null;
    //    foreach (GameObject go in gos)
    //    {
    //        next_station = go;
    //    }
    //    return next_station;

    //    //foreach (GameObject go in gos2)
    //    //{
    //    //    patient.SetDestination(waitingRoom.transform.position);
    //    //}

    //    //return next_station;
    //}

    //private void NextStation()
    //{
    //    if(next_station != null)
    //    {
    //        patient.SetDestination(stations[cont_station].transform.position);
    //    }
    //}

    //private void SetTimer()
    //{
    //    if (Station_Controller.setTimer == true && timer < 3)
    //    {
    //        timer += Time.deltaTime;            
    //    }
    //    if (timer >= 3 && cont_station < stations.Count)
    //    {
    //        timer = 0;
    //        Station_Controller.setTimer = false;
    //        this_available = true;
    //        cont_station++;
    //    }

    //}

    public float speed;
    public float waitTime;
    public float startTime;
    private NavMeshAgent patient;

    public Transform[] stations;
    public GameObject _waitingRoom;
    public int cont_station = 0;

    void Start()
    {
        waitTime = startTime;
        patient = GetComponent<NavMeshAgent>();
        //stations
    }

    void Update()
    {
        PatrolBehavior();
        WaitingRoom();
    }

    public void PatrolBehavior()
    {
        if (stations[cont_station].tag == "Available" || Vector2.Distance(patient.transform.position, stations[cont_station].position) < 0.4f)
        { 
            patient.SetDestination(stations[cont_station].transform.position);
            if (Vector2.Distance(patient.transform.position, stations[cont_station].position) < 0.4f)
            {
                if (cont_station >= stations.Length)
                {
                    Destroy(this.gameObject);
                }

                if (waitTime <= 0)
                {
                    stations[cont_station].transform.tag = "Available";
                    cont_station++;
                    waitTime = startTime;
                    
                }
                else
                {
                    stations[cont_station].transform.tag = "Occupied";
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    public void WaitingRoom()
    {
        if (stations[cont_station].tag == "Occupied" && Vector2.Distance(patient.transform.position, stations[cont_station].position) > 0.4f)
        {
            Debug.Log("vamo a esperar tantito");
            patient.SetDestination(_waitingRoom.transform.position);
        }
    }

           

}
