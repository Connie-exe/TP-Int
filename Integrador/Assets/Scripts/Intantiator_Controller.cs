using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intantiator_Controller : MonoBehaviour
{
    public List<GameObject> patients;
    public GameObject instantiatePos;
    public float timer = 7;
    private int cont = 0;
    //private float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       timer -= Time.deltaTime;
        SpawnPatients();
    }

    private void SpawnPatients()
    {
        if (timer <= 0 && cont <= 4)//si timer es menor o igual a 0
        {
            float offsetX = instantiatePos.transform.position.x;//se declara un float offsetX que es igual a la posición de la posición del instantiatePos en el eje x en unity
            int rnd = UnityEngine.Random.Range(0, patients.Count);//se declara un int (rnd) que genera un número random entre 0 y el número máximo de pacientes que hay en la lista patients
            Vector3 transform = new Vector3(offsetX, instantiatePos.transform.position.y, instantiatePos.transform.position.z);//aquí se declara la nueva posición del instantiate en el entorno 3d de unity
            Instantiate(patients[rnd], transform, Quaternion.identity);//esto permite que los enemigos spwneen en random lugares sin repetición
            cont++;
            timer = 7;//una vez que termine el for el timer valdrá 7 y saldrá del if
        }
    }
}
