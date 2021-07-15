using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Instantiator : MonoBehaviour
{
    public GameObject dirt;
    public Transform[] dirt_spots;
    public float timer = 9;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        SpawnDirt();
        timer -= Time.deltaTime;
    }

    private void SpawnDirt()
    {
        if (timer <= 0 && dirt == null)
        {
            for (int i = 0; i < dirt_spots.Length; i++)
            {
            
                //Vector3 transform = new Vector3(dirt_spots[i].position.x, dirt_spots[i].position.y, dirt_spots[i].position.z);
                Instantiate(dirt, dirt_spots[i].position, dirt_spots[i].rotation);
                timer = 10;
            }
        }
    }
}
