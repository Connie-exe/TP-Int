using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sintomas : MonoBehaviour
{
    private float temperature;
    public Text txt_temperatura;
    void Start()
    {
        txt_temperatura.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        CheckTemperature();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Head"))
        {
            Debug.Log("entro collider");
            if(this.gameObject.name == "Termometro")
            {
                temperature = Random.Range(37.5f, 39.6f);
                Debug.Log("midio temp");
            }

        }
    }

    public void CheckTemperature()
    {
        if(temperature > 37.5 && temperature < 38)
        {
            Debug.Log("temperatura normal");
            txt_temperatura.text = temperature + " Temperatura Normal";
        }else if (temperature > 38 && temperature < 38.6)
        {
            Debug.Log("fiebre");
            txt_temperatura.text = temperature + " Fiebre";
        }
        else if (temperature > 38.6 && temperature < 39.6)
        {
            Debug.Log("fiebre moderada");
            txt_temperatura.text = temperature + " Fiebre Moderada";
        }
        else if(temperature > 39.6)
        {
            Debug.Log("fiebre alta");
            txt_temperatura.text = temperature + " Fiebre Alta";
        }
    }
}
