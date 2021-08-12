using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public Text txt_notif;
    public GameObject notif_decor;
    public bool b_covid_notif;
    public GameObject covid_patient;   

    public GameObject panel_warning;
    public Text txt_explanation;
    public Text txt_explanation1;
    private string _explanation;

    public GameObject panel_LevelUp;

    public static bool b_VIP_achievement;

    //public static int cont_Levels;

    void Start()
    {
        txt_notif.text = "";
        b_covid_notif = false;
        notif_decor.SetActive(false);
        //b_isCreated = false;
        covid_patient = GameObject.FindGameObjectWithTag("COVID_Patient");

        panel_warning.SetActive(false);
        panel_LevelUp.SetActive(false);
        txt_explanation.text = "";
        txt_explanation1.text = "";

        //cont_Levels = 0;

        b_VIP_achievement = false;
    }

    
    void LateUpdate()
    {
        CovidNotif();
        OutOfVaccines();
        Loser();
        Winner();
    }

    public void CovidNotif()
    {
        covid_patient = GameObject.FindGameObjectWithTag("COVID_Patient");
        if (covid_patient == true && b_covid_notif == false)
        {
            txt_notif.text = "Oh no! This patient has COVID. Click on them to send them home or they're gonna spread the disease.";
            notif_decor.SetActive(true);
            b_covid_notif = true;
        }
        if (covid_patient == false)
        {
            txt_notif.text = "";
            notif_decor.SetActive(false);
        }
    }

    
    public void OutOfVaccines()
    {
        if (MoneySystem.cant_vac <= 0)
        {
            panel_warning.SetActive(true);
            _explanation = "You ran out of vaccines, buy some more at the store";
            txt_explanation.text = "" + _explanation;
            Time.timeScale = 0f;
        }
    }

    public void Loser()
    {
        if (COVID_Counter.cont >= 4)
        {
            panel_warning.SetActive(true);
            _explanation = "There were too many patients with COVID!! You lose!";
            txt_explanation.text = "" + _explanation;
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }

    public void Winner()
    {
        if(MoneySystem.cant_cured == 10 && MoneySystem.cant_founds == 1000 && MoneySystem.b_loan == false && Crack_Controller.cont_damage <= 0)
        {
            panel_LevelUp.SetActive(true);
            _explanation = "You have accomplished all the tasks of this level!";
            txt_explanation1.text = "" + _explanation;
            //cont_Levels ++;
            StartCoroutine(RestartGame());

        }
    }   
}
