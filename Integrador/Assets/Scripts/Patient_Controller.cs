using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patient_Controller : MonoBehaviour
{
    public List<GameObject> stations;
    private NavMeshAgent patient;
    public float timer;
    public int cont_station = 0;
    void Start()
    {
        timer = 0;
        patient = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NextStation();
        SetTimer();
    }

    private void NextStation()
    { 
        if(stations[cont_station].CompareTag("Available"))
        {
            patient.SetDestination(stations[cont_station].transform.position);
            patient.isStopped = false;
        }
        else
        { 
            patient.isStopped = true;
        }

        if(cont_station > stations.Count)
        {
            Destroy(this.gameObject);
        }
    }

    private void SetTimer()
    {
        if (Station_Controller.setTimer == true && timer < 3)
        {
            timer += Time.deltaTime;            
        }
        if (timer >= 3 && cont_station <= stations.Count)
        {
            timer = 0;
            Station_Controller.setTimer = false;
            cont_station++;
        }

    }

}
