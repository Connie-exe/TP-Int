using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants_Controller : MonoBehaviour
{
    public static bool b_needWater;
    public Material mat_healthyPlant;
    public Material mat_dyingPlant;
    public float timer;
    public float waitTime;
    void Start()
    {
        b_needWater = false;
        waitTime = timer;

    }
    void Update()
    {
        NeedWater();
    }

    public void NeedWater()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        
        if (waitTime <= 0)
        {
            meshRenderer.material = mat_dyingPlant;
            b_needWater = true;
        }
        if (b_needWater == false)
        {
            meshRenderer.material = mat_healthyPlant;
            waitTime -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Janitor"))
        {
            waitTime = timer;
            b_needWater = false;
        }
    }
}
