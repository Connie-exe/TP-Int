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

    public bool b_crack_notif;
    public GameObject cracks;

    public bool b_VIP_notif;
    public GameObject VIP_Patient;

    public bool b_inspector_notif;
    public bool b_founds_notif;

    public GameObject panel_warning;
    public Text txt_explanation;
    public Text txt_explanation1;
    private string _explanation;

    public GameObject panel_LevelUp;    

    void Start()
    {
        txt_notif.text = "";
        notif_decor.SetActive(false);

        b_covid_notif = false;
        covid_patient = GameObject.FindGameObjectWithTag("COVID_Patient");

        cracks = GameObject.FindGameObjectWithTag("Crack");
        b_crack_notif = false;

        VIP_Patient = GameObject.FindGameObjectWithTag("VIP_Patient");
        b_VIP_notif = false;

        b_inspector_notif = false;
        b_founds_notif = false;

        panel_warning.SetActive(false);
        panel_LevelUp.SetActive(false);
        txt_explanation.text = "";
        txt_explanation1.text = "";       
    }

    
    void LateUpdate()
    {
        CovidNotif();
        CrackNotif();
        InspectorNotif();
        VIPNotif();
        FoundsNotif();
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
            StartCoroutine(Notifs());
        }
    }

    public void CrackNotif()
    {
        cracks = GameObject.FindGameObjectWithTag("Crack");        
        if (cracks == true && b_crack_notif == false)
        {
            txt_notif.text = "Oh no! There has been an earthquake! Click on the cracks on the floor to repair them!";
            notif_decor.SetActive(true);
            b_crack_notif = true;
            StartCoroutine(Notifs());
        }
    }

    public void InspectorNotif()
    {
        if (Inspector_Instantiator.b_isCreated == true && b_inspector_notif == false)
        {
            txt_notif.text = "The inspector has arrived! Click on them to have a quick test. It will reward you!";
            notif_decor.SetActive(true);
            b_inspector_notif = true;
            StartCoroutine(Notifs());
        }
    }

    public void FoundsNotif()
    {
        if (MoneySystem.cant_founds <= 0 && b_founds_notif == false)
        {
            txt_notif.text = "Oh no! Our numbers are nearly in red! You can ask for a loan to the government at the store.";
            notif_decor.SetActive(true);
            b_founds_notif = true;
            StartCoroutine(Notifs());
        }
    }

    public void VIPNotif()
    {
        VIP_Patient = GameObject.FindGameObjectWithTag("VIP_patient");
        if (VIP_Patient == true && b_VIP_notif == false)
        {
            notif_decor.SetActive(true);
            txt_notif.text = "Look! The yellow one it's a VIP patient. If you click on them before the bar runs out they will donate supplies!";
            b_VIP_notif = true;
            StartCoroutine(Notifs());
        }
    }
    IEnumerator Notifs()
    {
        yield return new WaitForSeconds(3f);
        notif_decor.SetActive(false);
        txt_notif.text = "";
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
        if(MoneySystem.cant_cured >= 10 && MoneySystem.cant_founds >= 1000 && MoneySystem.b_loan == false && Crack_Controller.cont_damage <= 0)
        {
            panel_LevelUp.SetActive(true);
            _explanation = "You have accomplished all the tasks of this level!";
            txt_explanation1.text = "" + _explanation;
            //cont_Levels ++;
            StartCoroutine(RestartGame());

        }
    }   
}
