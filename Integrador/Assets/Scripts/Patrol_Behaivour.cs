using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol_Behaivour : MonoBehaviour
{
    internal NavMeshAgent agent;
    internal Vector3 destination;
    public float destinationTime = 4;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
    }


    void Update()
    {
        PatrolBehaviour();
    }

    private void PatrolBehaviour()
    {
        agent.SetDestination(destination);//se pone una destinación mediante el navmesh
        destinationTime -= Time.deltaTime;//el tiempo de destinación disminuye a medida que pasa el tiempo en unity
        if (destinationTime < 0)//si el tiempo de destinación es menor a 0
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));//la destinación se define con 2 valores random en el espacio, en sus ejes x y z
            destinationTime = 4;//y el valor del tiempo de destinación pasa a valer 4
        }
    }
}
