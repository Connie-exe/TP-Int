using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntertainingChild : MonoBehaviour
{
    public GameObject im_confused;
    public Text txt_confused;
    public static bool b_confused;
    private int randomnum;

    //public AudioSource audio_caramelo;
    //public AudioSource audio_juguete;
    //public AudioSource audio_cantar;
    void Start()
    {
        im_confused.SetActive(false);
        txt_confused.text = "";
        b_confused = false;
    }
    void Update()
    {
        //Distraction();
    }

    public void Distraction()
    {
        Debug.Log("entro distraction");
        randomnum = Random.Range(1, 3);
        switch (randomnum)
        {
            case 1:
                im_confused.SetActive(true);
                b_confused = true;
                txt_confused.text = "Excelente, el infante está distraído, ahora no llorará por la vacuna!";
                break;
            default:
                txt_confused.text = "Esa distracción no ha surtido efecto, prueba con otra.";
                break;
        }
    }
}
