using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Instantiator : MonoBehaviour
{
    public GameObject dirt;
    public Transform[] dirt_spots;
    //Vector3[] dirt_spots = new[] { new Vector3(-8.7f, 0.64f, 3.96f), new Vector3(-4.56f, 0.64f, -0.56f), new Vector3(-7.27f, 0.64f, -6.59f), new Vector3(4.49f, 0.64f, 4.65f), new Vector3(4.93f, .64f, -3.39f), new Vector3(8.32f, .64f, -7.27f), new Vector3(.54f, .64f, .91f) };
    //Quaternion spawnRotation = Quaternion.identity;
    public float timer = 9;
    //private int random;
    //private float time = 0;
    void Start()
    {
        //random = Random.Range(0, dirt_spots.Length);
    }

    // Update is called once per frame
    void Update()
    {   
        SpawnDirt();
        timer -= Time.deltaTime;
    }

    private void SpawnDirt()
    {
        if (timer <= 0)
        {
            for (int i = 0; i < dirt_spots.Length; i++)
            {
            
                //Vector3 transform = new Vector3(dirt_spots[i].position.x, dirt_spots[i].position.y, dirt_spots[i].position.z);
                Instantiate(dirt, dirt_spots[i].position, dirt_spots[i].rotation);
                timer = 9;
            }
        }
    }
}
