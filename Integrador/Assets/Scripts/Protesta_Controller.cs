using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protesta_Controller : MonoBehaviour
{
    public GameObject main_instantiator;
    void Start()
    {
        main_instantiator = GameObject.Find("MainInstantiator");
        main_instantiator.SetActive(false);
        Evaluation_System.seguridad -= 100;
    }

    public void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Security"))
        {
            main_instantiator.SetActive(true);
            Destroy(this.gameObject);
            Evaluation_System.seguridad += 150;

        }
    }
}
