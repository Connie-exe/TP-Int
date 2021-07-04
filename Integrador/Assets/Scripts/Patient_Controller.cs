using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patient_Controller : MonoBehaviour
{
    //public GameObject reception;
    //public GameObject testation;
    //public GameObject vaccination;
    public List<GameObject> stations;
    private NavMeshAgent patient;
    public  bool reception_occupied;
    public  bool testation_occupied;
    public  bool vaccination_occupied;
    public float timer;
    public int cont_station = 0;
    void Start()
    {
        reception_occupied = false;
        testation_occupied = false;
        vaccination_occupied = false;
        timer = 5f;
        patient = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NextStation();
    }

    private void NextStation()
    {
        if(reception_occupied == false && cont_station == 0)
        {
            patient.SetDestination(stations[cont_station].transform.position);
            if(reception_occupied == true)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                timer = 5;
                cont_station++;
            }
        }
        if(testation_occupied == false && cont_station == 1)
        {
            patient.SetDestination(stations[cont_station].transform.position);
            reception_occupied = false;
        }
        if (vaccination_occupied == false && cont_station == 2)
        {
            patient.SetDestination(stations[cont_station].transform.position);
        }
    }

    public void OnCollisionEnter(Collision collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Reception"))
        {
            reception_occupied = true;
            Debug.Log("Paciente en Recepción");
        }

        if (collision.gameObject.CompareTag("Testation"))
        {
            testation_occupied = true;
            //timer -= Time.deltaTime;
            //if (timer <= 0)
            //{
            //    testation_occupied = false;
            //    timer = 5;
            //    cont_station++;
            //}
            Debug.Log("Paciente en Testation");
        }

        if (collision.gameObject.CompareTag("Vaccination"))
        {
            vaccination_occupied = true;
            //timer -= Time.deltaTime;
            //if (timer <= 0)
            //{
            //    vaccination_occupied = false;
            //    timer = 5;
            //    cont_station++;
            //}
            Debug.Log("Paciente en Vaccination");
        }
    }

}
