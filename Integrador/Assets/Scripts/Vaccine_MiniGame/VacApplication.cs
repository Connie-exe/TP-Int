using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VacApplication : MonoBehaviour
{
    public Text txt_founds;
    public Text txt_supplies;
    public Image fillimage;
    public float timer;
    private float waitTime;

    public AudioSource audio_celebrando;
    void Start()
    {
        txt_founds.text = "" + MoneySystem.cant_founds;
        txt_supplies.text = "" + MoneySystem.cant_vac;
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

        if(waitTime <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vaccine"))
        {
            MoneySystem.cant_founds += 300;
            MoneySystem.cant_vac--;
            MoneySystem.cant_cured++;
            txt_founds.text = "" + MoneySystem.cant_founds;
            txt_supplies.text = "" + MoneySystem.cant_vac;
            Destroy(other.gameObject);
            StartCoroutine(BackToGame());
            if(VIP_Controller.b_isVIP == true)
            {
                //Instructions.b_VIP_achievement = true;
                MoneySystem.cant_vac += 5;
                txt_supplies.text = "" + MoneySystem.cant_vac;
                MoneySystem.cant_cured++;
            }
            audio_celebrando.Play();
        }
    }

    IEnumerator BackToGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
