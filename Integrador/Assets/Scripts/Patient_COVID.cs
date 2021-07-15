﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patient_COVID : MonoBehaviour
{
    internal GameObject closest_point;
    internal NavMeshAgent COVID_Patient;
    internal Vector3 destination;
    public float destinationTime = 4;

    private void Start()
    {
        COVID_Patient = GetComponent<NavMeshAgent>();
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
    }
    private void Update()
    {
        FindClosestPatient();
        FollowingBehaviour();
    }

    public GameObject FindClosestPatient()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Dirt");
        closest_point = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest_point = go;
                distance = curDistance;
            }
        }
        return closest_point;
    }

    private void FollowingBehaviour()
    {
        if (closest_point != null)
        {
            COVID_Patient.SetDestination(closest_point.transform.position);
        }
        else
        {
            PatrolBehaviour();
        }
    }
    private void PatrolBehaviour()
    {
        COVID_Patient.SetDestination(destination);//se pone una destinación mediante el navmesh
        destinationTime -= Time.deltaTime;//el tiempo de destinación disminuye a medida que pasa el tiempo en unity
        if (destinationTime < 0)//si el tiempo de destinación es menor a 0
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));//la destinación se define con 2 valores random en el espacio, en sus ejes x y z
            destinationTime = 4;//y el valor del tiempo de destinación pasa a valer 4
        }
    }

    public void OnMouseDown()
    {
        MoneySystem.cant_founds += 200;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Patient"))
        {
            collision.transform.gameObject.tag = "COVID_Patient";

        }
    }
}
