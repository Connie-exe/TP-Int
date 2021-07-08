using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor_Controller : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startTime;

    public Transform[] dirty_spots;
    private int randomSpot;

    void Start()
    {
        waitTime = startTime;
        randomSpot = Random.Range(0, dirty_spots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dirty_spots[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, dirty_spots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, dirty_spots.Length);
            waitTime = startTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
