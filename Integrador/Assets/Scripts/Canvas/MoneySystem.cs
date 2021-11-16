using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoneySystem : MonoBehaviour
{
    public Text txt_vaccined;
    public Text txt_founds;
    public Text txt_supplies;
    public Text txt_debt;
    public Text txt_explination;

    public static int cant_founds = 1000;
    public static int cant_cured = 0;
    public static int cant_vac = 5;
    public static int cant_debt = 0;

    public static bool b_loan;

    public GameObject panel_bancarrota;
    void Start()
    {
        txt_vaccined.text = "Vaccined: " + cant_cured;
        txt_founds.text = "Founds: " + cant_founds;
        txt_supplies.text = "Supplies: " + cant_vac;
        txt_debt.text = "Debt: " + cant_debt;
        b_loan = false;
        panel_bancarrota.SetActive(false);
        
    }
    void Update()
    {
        PrintData();
        Bankruptcy();
    }

    public void PrintData()
    {
        txt_vaccined.text = "Vaccined " + cant_cured;
        txt_founds.text = "Founds: " + cant_founds;
        txt_supplies.text = "Supplies: " + cant_vac;
        txt_debt.text = "Debt: " + cant_debt;
    }

    public void Bankruptcy()
    {
        if(cant_founds <= -1000)
        {            
            panel_bancarrota.SetActive(true);
            txt_explination.text = "Oh no! Tu vacunatorio a presentado bancarrota! Intentalo de nuevo!";
            Time.timeScale = 1f;
            StartCoroutine(BackToMenu());
        }
    }

    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}
