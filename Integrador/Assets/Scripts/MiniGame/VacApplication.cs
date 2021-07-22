using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VacApplication : MonoBehaviour
{
    public Text txt_founds;
    public Image fillimage;
    public float timer;
    private float waitTime;
    void Start()
    {
        txt_founds.text = "Founds: " + MoneySystem.cant_founds;
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
            txt_founds.text = "Founds: " + MoneySystem.cant_founds;
            Destroy(other.gameObject);
            StartCoroutine(BackToGame());
        }
    }

    IEnumerator BackToGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
