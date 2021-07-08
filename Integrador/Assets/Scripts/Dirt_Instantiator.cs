using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Instantiator : MonoBehaviour
{
    public GameObject dirt;
    public Transform[] dirt_spots;
    public float timer = 3;
    private int random;
    //private float time = 0;
    void Start()
    {
        random = Random.Range(0, dirt_spots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        SpawnPatients();
    }

    private void SpawnPatients()
    {
        if (timer <= 0)//si timer es menor o igual a 0
        {
            Vector3 transform = new Vector3(dirt_spots[random].position.x, dirt_spots[random].position.y, dirt_spots[random].position.z);//aquí se declara la nueva posición del instantiate en el entorno 3d de unity
            Instantiate(dirt, transform, Quaternion.identity);//esto permite que los enemigos spwneen en random lugares sin repetición
            Vector3 transform2 = new Vector3(dirt_spots[random].position.x, dirt_spots[random].position.y, dirt_spots[random].position.z);//aquí se declara la nueva posición del instantiate en el entorno 3d de unity
            Instantiate(dirt, transform2, Quaternion.identity);//esto permite que los enemigos spwneen en random lugares sin repetición
            timer = 3;//una vez que termine el for el timer valdrá 7 y saldrá del if
        }
    }
}
