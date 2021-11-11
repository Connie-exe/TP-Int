using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sintomas : MonoBehaviour
{
    private double temperature;
    private int throatache;
    private int rashSkin;
    private int preguntas;
    public Text txt_temperatura;
    public Text txt_throatache;
    public Text txt_rashSkin;
    public Text txt_headache;
    public Text txt_taste;
    public Text txt_chest;
    private bool b_temperatura;
    private bool b_throatache;
    private bool b_rashSkin;

    public int cont_diagnostico = 0;
    public static bool b_diagnostico;

    public static float probabilidades_escondidas = 0f;
    public float peek;
    void Start()
    {
        txt_temperatura.text = "";
        b_temperatura = false;
        txt_throatache.text = "";
        b_throatache = false;
        txt_rashSkin.text = "";
        b_rashSkin = false;
        b_diagnostico = false;        

    }

    // Update is called once per frame
    void Update()
    {
        peek = probabilidades_escondidas;
        if(cont_diagnostico == 3)
        {
            b_diagnostico = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Head"))
        {
            //Debug.Log("entro collider");
            if(this.gameObject.name == "Termometro" && b_temperatura == false)
            {                
                temperature = Random.Range(37.5f, 39.6f);
                temperature = System.Math.Round(temperature, 2);
                Debug.Log(temperature);
                CheckTemperature();
                //b_diagnostico = true;                
                b_temperatura = true;
            }
            if(this.gameObject.name == "Palillo de Lengua" && b_throatache == false)
            {
                throatache = Random.Range(1, 4);
                CheckThroatache();
                b_throatache = true;
                //b_diagnostico = true;
            }

        }
        if(other.gameObject.CompareTag("Body"))
        {
            if(this.gameObject.name == "Lupa" && b_rashSkin == false)
            {
                rashSkin = Random.Range(1, 4);
                CheckSkin();
                b_rashSkin = true;
                //b_diagnostico = true;
            }
        }
    }

    public void CheckTemperature()
    {
        
        if (temperature > 37.5 && temperature < 38)
        {
            //Debug.Log("temperatura normal");
            txt_temperatura.text = temperature + " Temperatura Normal";
        }
        else if (temperature > 38 && temperature < 38.6)
        {
            //Debug.Log("fiebre");
            txt_temperatura.text = temperature + " Fiebre";
            Diagnostico.probabilidades += 10;
        }
        else if (temperature > 38.6 && temperature < 39.6)
        {
            //Debug.Log("fiebre moderada");
            txt_temperatura.text = temperature + " Fiebre Moderada";
            Diagnostico.probabilidades += 15;
        }
        else if(temperature > 39.6)
        {
            //Debug.Log("fiebre alta");
            txt_temperatura.text = temperature + " Fiebre Alta";
            Diagnostico.probabilidades += 30;
        }
    }

    public void CheckThroatache()
    {
        switch (throatache)
        {
            case 1:
                txt_throatache.text = "El paciente presenta la gargante ligeramente inflamada.";
                Diagnostico.probabilidades += 15;
                break;
            case 2:
                txt_throatache.text = "El paciente no presenta anomalías en la garganta.";
                break;
            default:
                txt_throatache.text = "El paciente presenta la garganta muy inflamada";
                Diagnostico.probabilidades += 20;
                break;
        }
    }

    public void CheckSkin()
    {
        switch (rashSkin)
        {
            case 1:
                txt_rashSkin.text = "Resultados Inconclusos";
                break;
            case 2:
                txt_rashSkin.text = "El paciente presenta erupciones en la piel";
                Diagnostico.probabilidades += 10;
                break;
            default:
                txt_rashSkin.text = "El paciente no presenta erupciones en la piel";
                break;
        }
    }

    public void CheckHeadache()
    {
        preguntas = Random.Range(1, 4);
        switch (rashSkin)
        {
            case 1:
                txt_headache.text = "El paciente no presenta dolor de cabeza";
                break;
            case 2:
                txt_headache.text = "El paciente presenta ligeros mareos.";
                break;
            default:
                txt_headache.text = "El paciente presenta dolor de cabeza.";
                probabilidades_escondidas += 35;
                break;
        }
        //b_diagnostico = true;
        cont_diagnostico++;
    }

    public void CheckOlfatoGusto()
    {
        preguntas = Random.Range(1, 5);
        switch (preguntas)
        {
            case 1:
                txt_taste.text = "Sin cambios.";
                break;
            case 2:
                txt_taste.text = "El paciente no tiene gusto";
                probabilidades_escondidas += 35;
                break;
            case 3:
                txt_taste.text = "El paciente no tiene olfato";
                probabilidades_escondidas += 30;
                break;
            default:
                txt_taste.text = "El paciente no tiene ni olfato ni gusto.";
                probabilidades_escondidas += 40;
                break;
        }
        //b_diagnostico = true;
        cont_diagnostico++;
    }

    public void CheckChest()
    {
        preguntas = Random.Range(1, 4);
        switch (preguntas)
        {
            case 1:
                txt_chest.text = "El paciente no presenta dolor en el pecho.";
                break;
            case 2:
                txt_chest.text = "El paciente siente dolor al respirar";
                probabilidades_escondidas += 20;
                break;
            default:
                txt_chest.text = "El paciente siente dolor en la espalda.";
                probabilidades_escondidas += 5;
                break;           
        }
        //b_diagnostico = true;
        cont_diagnostico++;
    }
}
