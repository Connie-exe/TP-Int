using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Instantiator : MonoBehaviour
{
    public GameObject dirt;
    public Transform[] dirt_spots;
    public static float timer;
    public float waitTime;
    void Start()
    {
        TimerSet();
        waitTime = timer;
    }

    // Update is called once per frame
    void Update()
    {        
        SpawnDirt();
        waitTime -= Time.deltaTime;
    }

    public void TimerSet()
    {
        switch (Evaluation_System.cont_alcoholEnGel)
        {
            case -1:
                timer = 10;
                break;
            case 0:
                timer = 15;
                break;
            case 1:
                timer = 20;
                break;
            case 2:
                timer = 25;
                break;           
            case 3:
                timer = 30;
                break;
            default:
                timer = 10;
                break;
        }
    }
    private void SpawnDirt()
    {
        if (waitTime <= 0)
        {
            for (int i = 0; i < dirt_spots.Length; i++)
            {
            
                //Vector3 transform = new Vector3(dirt_spots[i].position.x, dirt_spots[i].position.y, dirt_spots[i].position.z);
                Instantiate(dirt, dirt_spots[i].position, dirt_spots[i].rotation);
                Evaluation_System.limpieza -= 70;
                TimerSet();
                waitTime = timer;
            }
        }
    }
}
