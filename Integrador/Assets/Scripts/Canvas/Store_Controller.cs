﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store_Controller : MonoBehaviour
{
    public Dropdown drop_loan;
    private int loan_selected;

    public static bool inspector_test_done;

    void Start()
    {
        inspector_test_done = false;
    }
  
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenStore()
    {
        Time.timeScale = 0f;
    }

    public void CloseStore()
    {
        Time.timeScale = 1f;
    }

    public void MoreVaccines()
    {
        if(MoneySystem.cant_founds >= 150)
        {
            MoneySystem.cant_vac++;
            MoneySystem.cant_founds -= 150;
        }
    }

    public void LoanSelected()
    {
        if (drop_loan.value == 0)
        {
            loan_selected = 0;
        }
        else if (drop_loan.value == 1)
        {
            loan_selected = 1;
        }
        else if (drop_loan.value == 2)
        {
            loan_selected = 2;
        }
        AddLoan();
    }

    public void AddLoan()
    {
        if (loan_selected == 0)
        {
            MoneySystem.cant_founds += 500;
            MoneySystem.cant_debt += 575;
            MoneySystem.b_loan = true;
        }
        else if (loan_selected == 1)
        {
            MoneySystem.cant_founds += 800;
            MoneySystem.cant_debt += 920;
            MoneySystem.b_loan = true;
        }
        else if (loan_selected == 2)
        {
            MoneySystem.cant_founds += 1000;
            MoneySystem.cant_debt += 1150;
            MoneySystem.b_loan = true;
        }
    }

    public void AddNurse()
    {
        if(Employees_Controller.cant_Nurse < Employees_Controller.max_Nurse && MoneySystem.cant_founds >= 500)
        {
            Employees_Controller.cant_Nurse++;
            MoneySystem.cant_founds -= 500;
        }        
    }

    public void AddJanitor()
    {
        if (Employees_Controller.cant_Janitor < Employees_Controller.max_Janitor && MoneySystem.cant_founds >= 450)
        {
            Employees_Controller.cant_Janitor++;
            MoneySystem.cant_founds -= 450;
            Employees_Controller.b_add_janitor = true;
            Employees_Controller.cont_janitor_active++;
        }
    }

    public void AddPublicist()
    {
       if(Employees_Controller.cant_Publicist < Employees_Controller.max_Janitor && MoneySystem.cant_founds >= 550)
        {
            Employees_Controller.cant_Publicist++;
            MoneySystem.cant_founds -= 550;
        }
    }

    public void PayDebt()
    {
        if(MoneySystem.cant_founds >= MoneySystem.cant_debt)
        {
            MoneySystem.cant_founds -= MoneySystem.cant_debt;
            MoneySystem.cant_debt = 0;
            MoneySystem.b_loan = false;
        }
    } 
    
    public void MiniGame_Diagnostico()
    {
        SceneManager.LoadScene("CheckPatient");
    }

    public void MiniGame_Vacuna()
    {
        SceneManager.LoadScene("Vaccine_MiniGame");
    }

    public void MiniGame_VacunaChild()
    {
        SceneManager.LoadScene("ChildVaccine_Minigame");
    }

    public void Inspector()
    {
        MoneySystem.cant_founds += 700;
        MoneySystem.cant_debt = 0;
        inspector_test_done = true;
    }

    public void CloseTest()
    {
        Time.timeScale = 1f;
        inspector_test_done = true;
    }

}
