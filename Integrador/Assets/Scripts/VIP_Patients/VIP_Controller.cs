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

    public GameObject notif_decor;
    public Text txt_VIP_notif;

    void Start()
    {
        b_isVIP = false;
        waitTime = timer;
        vip_patient = GameObject.FindGameObjectWithTag("VIP_patient");
        timer_decor.SetActive(false);
        notif_decor.SetActive(false);
        txt_VIP_notif.text = "";

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
            Notifs();
            
            timer_decor.SetActive(true);
            waitTime -= Time.deltaTime;
            fillimage.fillAmount = waitTime / timer;

            if (waitTime <= 0)
            {
                Destroy(vip_patient.gameObject);
                timer_decor.SetActive(false);
            }
        }
    }

    public void Notifs()
    {
        notif_decor.SetActive(true);
        txt_VIP_notif.text = "Look! The yellow one it's a VIP patient. If you click on them before the bar runs out they will donate supplies!";
        StartCoroutine(Notifs_false());
    }

    IEnumerator Notifs_false()
    {
        yield return new WaitForSeconds(3f);
        notif_decor.SetActive(false);
        txt_VIP_notif.text = "";
    }


}
    
