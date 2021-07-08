using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patient_Controller : MonoBehaviour
{
    public float speed;
    public float waitTime;
    private NavMeshAgent patient;

    public Transform[] stations;
    public GameObject _waitingRoom;
    public int cont_station = 0;

    void Start()
    {
        waitTime = Employees_Controller.startTime;
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
                if (waitTime <= 0)
                {
                    stations[cont_station].transform.tag = "Available";
                    cont_station++;
                    waitTime = Employees_Controller.startTime;

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

    public void OnTriggerEnter(Collider collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Dirt"))//con un objeto con etiqueta Projectile
        {
            speed -= 2;//se destruye el objeto con el que se colisiona
        }
    }

    public void OnTriggerExit(Collider collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Dirt"))//con un objeto con etiqueta Projectile
        {
            speed += 2;//se destruye el objeto con el que se colisiona
        }
    }
}
