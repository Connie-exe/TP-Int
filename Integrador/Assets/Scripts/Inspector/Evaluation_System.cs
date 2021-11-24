using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evaluation_System : MonoBehaviour
{
    public static int decoración;
    public static int limpieza;
    public static int seguridad;
    public float EvGral;

    public Text txt_decoración;
    public Text txt_limpieza;
    public Text txt_seguridad;
    public Text txt_EvGral;

    public GameObject[] plants;
    public static bool b_add_plant;
    public static int cont_plant_onMap = -1;
    public static int max_plants;

    public static int cont_alcoholEnGel;
    void Start()
    {
        max_plants = plants.Length;
        txt_decoración.text = "Decoración:" + decoración;
        txt_limpieza.text = "Limpieza: " + limpieza;
        txt_seguridad.text = "Seguridad: " + seguridad;
    }

    // Update is called once per frame
    void Update()
    {
        PlantsOnMap();
        ClinicLevel();
    }

    public void PlantsOnMap()
    {
        if(b_add_plant == true)
        {
            plants[cont_plant_onMap].SetActive(true);
        }
        b_add_plant = false;
    }

    public void ClinicLevel()
    {
        EvGral = (decoración + limpieza + seguridad) / 3;
        txt_EvGral.text = "Nivel del Hospital: " + EvGral;
        //switch (EvGral)
        //{
        //    case <= 4:
        //        txt_EvGral.text = "Malo";
        //            break;
        //    case >= 6:
        //        txt_EvGral.text = "Bueno";
        //        break;                
        //    default:
        //        txt_EvGral.text = "Normal";
        //        break;
        //}
    }
}
