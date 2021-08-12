﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_Controller : MonoBehaviour
{
    public GameObject damage;
    public Transform[] damage_spots;
    public static int cant_damageSpots;
    public float timer = 20;

    public bool b_isCreated;
    private Shake_Effect shake;
   
    void Start()
    {
        cant_damageSpots = damage_spots.Length;
        b_isCreated = false;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake_Effect>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCrack();
        
        timer -= Time.deltaTime;
    }

    private void SpawnCrack()
    {
        if (timer <= 0 && b_isCreated == false)
        {
            for (int i = 0; i < damage_spots.Length; i++)
            {

                //Vector3 transform = new Vector3(dirt_spots[i].position.x, dirt_spots[i].position.y, dirt_spots[i].position.z);
                Instantiate(damage, damage_spots[i].position, damage_spots[i].rotation);
                timer = 10;
                shake.CamShake();
            }
            b_isCreated = true; 
        }
    }
}