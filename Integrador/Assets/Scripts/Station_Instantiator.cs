using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station_Instantiator : MonoBehaviour
{
    public List<GameObject> stations;
    public Transform[] station_spots;
    public float timer = 0.5f;
    private bool b_created;
    void Start()
    {
        b_created = false;
    }
    void Update()
    {
        SpawnStation();
        timer -= Time.deltaTime;
    }

    private void SpawnStation()
    {
        if (timer <= 0 && b_created == false)
        {
            for (int i = 0; i < station_spots.Length; i++)
            {

                //Vector3 transform = new Vector3(dirt_spots[i].position.x, dirt_spots[i].position.y, dirt_spots[i].position.z);
                Instantiate(stations[i], station_spots[i].position, station_spots[i].rotation);
                b_created = true;
            }
        }
    }
}
