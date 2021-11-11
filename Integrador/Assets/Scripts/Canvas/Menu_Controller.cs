using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public GameObject panel_money;
    public GameObject panel_menu;
    void Start()
    {
        panel_money.SetActive(false);
        panel_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DropMoneyPanel()
    {
        panel_money.SetActive(true);
    }
    public void UnDropMoneyPanel()
    {
        panel_money.SetActive(false);
    }

    public void DropMenu()
    {
        panel_menu.SetActive(true);
    }

    public void UnDropMenu()
    {
        panel_menu.SetActive(false);
    }
}
