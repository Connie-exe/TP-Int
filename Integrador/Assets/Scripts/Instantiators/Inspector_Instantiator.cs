using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Instantiator : MonoBehaviour
{
    public GameObject inspector;
    public float timer = 10;

    public static bool b_isCreated;    

    void Start()
    {        
        b_isCreated = false;       
    }

    // Update is called once per frame
    void Update()
    {
        SpawnInspector();
        timer -= Time.deltaTime;
    }

    private void SpawnInspector()
    {
        if (timer <= 0 && b_isCreated == false)
        {
            Instantiate(inspector, this.transform.position, this.transform.rotation);
            timer = 10;
            b_isCreated = true;
        }
    }

}
