using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Diagnostico : MonoBehaviour
{
    public static float probabilidades = 0f;
    public Text txt_probabilidades;
    public Text txt_founds;
    public Button btn_desicion;
    private bool b_segundaOpinion;

    public GameObject panel_afterDesicion;
    public Text txt_result;

    public AudioSource audio_celebrando;
    void Start()
    {        
        btn_desicion.enabled = false;
        panel_afterDesicion.SetActive(false);
        b_segundaOpinion = false;
    }

    // Update is called once per frame
    void Update()
    {
        txt_probabilidades.text = "Probabilidades de COVID: " + probabilidades + " %";
        txt_founds.text = "" + MoneySystem.cant_founds;
        Desicion();
    }

    public void Desicion()
    {
        if(Sintomas.b_diagnostico == true)
        {
            btn_desicion.enabled = true;
        }
    }

    public void DarAlta()
    {
        panel_afterDesicion.SetActive(true);
        if (probabilidades + Sintomas.probabilidades_escondidas > 50)
        {            
            txt_result.text = "El paciente que has dado de alta tenía COVID, el gobierno te cobrará una multa de $500";
            MoneySystem.cant_founds -= 500;
        }
        else
        {
            txt_result.text = "Buen trabajo! Ese paciente no tenía COVID, el gobierno te recompensará con $500";
            MoneySystem.cant_founds += 500;
            audio_celebrando.Play();
        }
        StartCoroutine(BackToGame());
    }

    public void TratarCOVID()
    {
        panel_afterDesicion.SetActive(true);
        if(b_segundaOpinion == true)
        {
            probabilidades -= Sintomas.probabilidades_escondidas;
        }
        if (probabilidades + Sintomas.probabilidades_escondidas > 55)
        {
            txt_result.text = "Buen trabajo! Ahora el paciente podrá cuidarse a sí mismo y a los demás. Justo a tiempo! El gobierno te recompensará con $1000";
            MoneySystem.cant_founds += 1000;
            audio_celebrando.Play();
        }
        else
        {
            txt_result.text = "Has diagnosticado mal al paciente, eso es un problema, intentalo mejor para la próxima.";
        }
        StartCoroutine(BackToGame());
    }

    public void SegundaOpinion()
    {
        panel_afterDesicion.SetActive(true);
        MoneySystem.cant_founds -= 200;
        txt_result.text = "Otros colegas doctores han deliberado que la respuesta de las preguntas afecta a las probabilidades de COVID en un " + Sintomas.probabilidades_escondidas + " %";
        probabilidades += Sintomas.probabilidades_escondidas;
        b_segundaOpinion = true;
    }

    IEnumerator BackToGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SampleScene");
    }

}
