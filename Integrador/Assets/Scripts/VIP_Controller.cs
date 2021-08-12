using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIP_Controller : MonoBehaviour
{
    public GameObject timer_decor;
    public Image fillimage;
    public float timer;
    public static float waitTime;
    public static bool b_isVIP;

    public GameObject vip_patient;

    void Start()
    {
        b_isVIP = false;
        waitTime = timer;
        vip_patient = GameObject.FindGameObjectWithTag("VIP_patient");
        timer_decor.SetActive(false);
    }
    void Update()
    {
        SetTimer();
    }

    public void SetTimer()
    {
        vip_patient = GameObject.FindGameObjectWithTag("VIP_patient");
        if(vip_patient == true)
        {
            timer_decor.SetActive(true);
            waitTime -= Time.deltaTime;
            fillimage.fillAmount = waitTime / timer;

            if (waitTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

   
}
    
