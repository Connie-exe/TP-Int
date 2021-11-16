﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VacApplication_Children : MonoBehaviour
{
    public Text txt_supplies;
    public Image fillimage;
    public float timer;
    private float waitTime;
    public Text txt_cryingbaby;
    void Start()
    {
        txt_supplies.text = "Supplies: " + MoneySystem.cant_vac;
        waitTime = timer;
        //fillimage = GetComponent<Image>();
    }
    void Update()
    {
        SetTimer();
    }

    public void SetTimer()
    {
        waitTime -= Time.deltaTime;
        fillimage.fillAmount = waitTime / timer;

        if (waitTime <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vaccine") && EntertainingChild.b_confused == true)
        {           
            MoneySystem.cant_vac--;
            MoneySystem.cant_cured++;
            txt_supplies.text = "Supplies: " + MoneySystem.cant_vac;
            Destroy(other.gameObject);
            StartCoroutine(BackToGame());           
        }
        if (other.gameObject.CompareTag("Vaccine") && EntertainingChild.b_confused == false)
        {
            MoneySystem.cant_vac--;
            txt_supplies.text = "Supplies: " + MoneySystem.cant_vac;
            txt_cryingbaby.text = "Oh no! El infante no permitió que le pusieras la vacuna porque no lo has distraido de forma correcta.";
            Destroy(other.gameObject);
            StartCoroutine(BackToGame());
        }
    }

    IEnumerator BackToGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
    }
}
