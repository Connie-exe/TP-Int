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

    public Transform[] stations;
    public GameObject _waitingRoom;
    public int cont_station = 0;

    //public GameObject sick_patient;
    //public Transform sick_patientPos;

    void Start()
    {
        waitTime = Employees_Controller.startTime;
        //fillTime = waitTime;
        patient = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Contagious();
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
                    //fillTime = Employees_Controller.startTime;
                    //StationTime.b_occupied = false;                    
                }
                else
                {
                    stations[cont_station].transform.tag = "Occupied";
                    StationTime.b_occupied = true;
                    waitTime -= Time.deltaTime;
                    //fillTime -= Time.deltaTime;
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

    public void OnTriggerEnter(Collider collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Dirt"))//con un objeto con etiqueta Projectile
        {
            speed -= 4;//se destruye el objeto con el que se colisiona
        }
    }

    public void OnTriggerExit(Collider collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Dirt"))//con un objeto con etiqueta Projectile
        {
            speed += 4;//se destruye el objeto con el que se colisiona
        }
    }
}
