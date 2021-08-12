using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inspector : MonoBehaviour
{
    public static bool b_inspector_test;

    internal NavMeshAgent _inspector;
    internal Vector3 destination;
    public float destinationTime = 4;
    private void Start()
    {
        b_inspector_test = false;

        _inspector = GetComponent<NavMeshAgent>();
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
    }
    private void Update()
    {
        PatrolBehaviour();
    }

    private void PatrolBehaviour()
    {
        _inspector.SetDestination(destination);
        destinationTime -= Time.deltaTime;
        if (destinationTime < 0)
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));
            destinationTime = 4;
        }
    }
    public void OnMouseDown()
    {
        Time.timeScale = 0f;
        b_inspector_test = true;
    }
}
