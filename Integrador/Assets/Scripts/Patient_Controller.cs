using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patient_Controller : MonoBehaviour
{
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
        if ((stations[cont_station].tag == "Available" || Vector2.Distance(patient.transform.position, stations[cont_station].position) < 0.4f) && stations[cont_station] != null)
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
            patient.SetDestination(_waitingRoom.transform.position);
        }
    }

           

}
