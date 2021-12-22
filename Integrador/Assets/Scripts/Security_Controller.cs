using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Security_Controller : MonoBehaviour
{
    internal GameObject closest_protest;
    public GameObject security_spot;
    internal NavMeshAgent security;
    internal Vector3 destination;
    public float destinationTime = 4;
    void Start()
    {        
        security = GetComponent<NavMeshAgent>();
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
    }
    void Update()
    {        
        FindClosestProtest();
        FollowingBehaviour();
    }    
   
    public GameObject FindClosestProtest()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Protest");
        closest_protest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest_protest = go;
                distance = curDistance;
            }
        }
        return closest_protest;
    }

    private void FollowingBehaviour()
    {
        if (closest_protest != null)
        {
            security.SetDestination(closest_protest.transform.position);
        }
        else
        {
            //security.SetDestination(security_spot.transform.position);
            PatrolBehaviour();
        }
    }

    private void PatrolBehaviour()
    {
        security.SetDestination(destination);//se pone una destinación mediante el navmesh
        destinationTime -= Time.deltaTime;//el tiempo de destinación disminuye a medida que pasa el tiempo en unity
        if (destinationTime < 0)//si el tiempo de destinación es menor a 0
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));//la destinación se define con 2 valores random en el espacio, en sus ejes x y z
            destinationTime = 4;//y el valor del tiempo de destinación pasa a valer 4
        }
    }
}
