using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Patient_Controller : MonoBehaviour
{
    public float speed;
    public float waitTime;
    private NavMeshAgent patient;

    public Transform[] stations;
    public GameObject _waitingRoom;
    public int cont_station = 0;

    //public Image fillImage;
    //public Image clockimage;

    void Start()
    {
        waitTime = Employees_Controller.startTime;
        patient = GetComponent<NavMeshAgent>();
        //fillImage = GetComponent<Image>();
        //clockimage = GetComponent<Image>();
        //fillImage.enabled = false;
        //clockimage.enabled = false;
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
                    //fillImage.enabled = true;
                    //clockimage.enabled = true;
                    //fillImage.fillAmount = Employees_Controller.startTime;
                }
                else
                {
                    stations[cont_station].transform.tag = "Occupied";
                    waitTime -= Time.deltaTime;
                    //fillImage.enabled = true;
                    //clockimage.enabled = true;
                    //fillImage.fillAmount = waitTime / Employees_Controller.startTime;
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
