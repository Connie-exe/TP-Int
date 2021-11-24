using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Janitor_Controller : MonoBehaviour
{
    internal GameObject closest_dirt;
    internal GameObject closest_plant;
    internal NavMeshAgent janitor;
    internal Vector3 destination;
    public float destinationTime = 4;
    void Start()
    {
        janitor = GetComponent<NavMeshAgent>();
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
    }
    void Update()
    {
        FindClosestDirt();
        FindClosestPlant();
        FollowingBehaviour();
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Dirt"))
        {
            Destroy(other.gameObject);
            Evaluation_System.limpieza += 10;
        }       
    }
    public GameObject FindClosestDirt()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Dirt");
        closest_dirt = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest_dirt = go;
                distance = curDistance;
            }
        }
        return closest_dirt;
    }

    public GameObject FindClosestPlant()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Plant");
        closest_plant = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest_plant = go;
                distance = curDistance;
            }
        }
        return closest_plant;
    }

    private void FollowingBehaviour()
    {
        if (closest_dirt != null)
        {
            janitor.SetDestination(closest_dirt.transform.position);
        }
        else if(Plants_Controller.b_needWater == true)
        {
            janitor.SetDestination(closest_plant.transform.position);
        }
        else
        {
            PatrolBehaviour();
        }
    }
    private void PatrolBehaviour()
    {
        janitor.SetDestination(destination);//se pone una destinación mediante el navmesh
        destinationTime -= Time.deltaTime;//el tiempo de destinación disminuye a medida que pasa el tiempo en unity
        if (destinationTime < 0)//si el tiempo de destinación es menor a 0
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));//la destinación se define con 2 valores random en el espacio, en sus ejes x y z
            destinationTime = 4;//y el valor del tiempo de destinación pasa a valer 4
        }
    }
}
