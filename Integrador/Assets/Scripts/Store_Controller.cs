using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Controller : MonoBehaviour
{
    public Dropdown drop_loan;
    private int loan_selected;
    void Start()
    {
        
    }
  
    void Update()
    {
        
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
            //AddLoan();
        }
        else if (drop_loan.value == 1)
        {
            loan_selected = 1;
            //AddLoan();
        }
        else if (drop_loan.value == 2)
        {
            loan_selected = 2;
            //AddLoan();
        }
        AddLoan();
    }

    public void AddLoan()
    {
        if (loan_selected == 0)
        {
            MoneySystem.cant_founds += 500;
        }
        else if (loan_selected == 1)
        {
            MoneySystem.cant_founds += 800;
        }
        else if (loan_selected == 2)
        {
            MoneySystem.cant_founds += 1000;
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
}
