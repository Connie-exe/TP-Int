using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protest_Instantiator : MonoBehaviour
{
    public GameObject protest;
    public float timer;

    public static bool b_isCreated;

    void Start()
    {
        b_isCreated = false;
    }

    void Update()
    {
        SpawnProtest();
        timer -= Time.deltaTime;
    }

    private void SpawnProtest()
    {
        if (timer <= 0 && b_isCreated == false)
        {
            Instantiate(protest, this.transform.position, this.transform.rotation);
            timer = 10;
            b_isCreated = true;
        }
    }
}
