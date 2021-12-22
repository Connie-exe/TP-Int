using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store_Controller : MonoBehaviour
{
    public Dropdown drop_loan;
    private int loan_selected;

    public static bool inspector_test_done;
    private int cont_loan;

    public static bool b_antiTerremoto;
    public static bool b_waitingRoom;

    public AudioSource audio_chachin;
    void Start()
    {
        inspector_test_done = false;
        cont_loan = 0;
        b_antiTerremoto = false;
        b_waitingRoom = false;
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
        MoneySystem.cant_vac++;
        MoneySystem.cant_founds -= 150;
        CajaCachin();        
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
        if (loan_selected == 0 && cont_loan <= 2)
        {
            MoneySystem.cant_founds += 500;
            MoneySystem.cant_debt += 575;
            MoneySystem.b_loan = true;
            cont_loan++;
        }
        else if (loan_selected == 1 && cont_loan <= 2)
        {
            MoneySystem.cant_founds += 800;
            MoneySystem.cant_debt += 920;
            MoneySystem.b_loan = true;
            cont_loan++;
        }
        else if (loan_selected == 2 && cont_loan <= 2)
        {
            MoneySystem.cant_founds += 1000;
            MoneySystem.cant_debt += 1150;
            MoneySystem.b_loan = true;
            cont_loan++;
        }
    }

    public void AddNurse()
    {
        if(Employees_Controller.cant_Nurse < Employees_Controller.max_Nurse)
        {
            Employees_Controller.cant_Nurse++;
            MoneySystem.cant_founds -= 500;
            CajaCachin();
        }        
    }

    public void AddJanitor()
    {
        if (Employees_Controller.cant_Janitor < Employees_Controller.max_Janitor)
        {
            Employees_Controller.cant_Janitor++;
            MoneySystem.cant_founds -= 450;
            Employees_Controller.b_add_janitor = true;
            Employees_Controller.cont_janitor_active++;
            Evaluation_System.limpieza += 35;
            CajaCachin();
        }
    }

    public void AddPublicist()
    {
       if(Employees_Controller.cant_Publicist < Employees_Controller.max_Janitor)
        {
            Employees_Controller.cant_Publicist++;
            MoneySystem.cant_founds -= 550;
            CajaCachin();
        }
    }

    public void AddSecurity()
    {
        if(Employees_Controller.b_security == false)
        {
            Employees_Controller.b_security = true;
            Debug.Log(" " + Employees_Controller.b_security);
            Employees_Controller.cant_Security++;
            MoneySystem.cant_founds -= 600;
            Evaluation_System.seguridad += 70;
            CajaCachin();
        }
    }

    public void PayDebt()
    {
        if(MoneySystem.cant_founds >= MoneySystem.cant_debt)
        {
            MoneySystem.cant_founds -= MoneySystem.cant_debt;
            MoneySystem.cant_debt = 0;
            MoneySystem.b_loan = false;
            cont_loan = 0;
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

    public void AntiTerremotos()
    {
        b_antiTerremoto = true;
        MoneySystem.cant_founds -= 800;
        Evaluation_System.seguridad += 100;
        CajaCachin();
    }

    public void AddWaitingRoom()
    {
        b_waitingRoom = true;
        MoneySystem.cant_founds -= 600;
        Evaluation_System.decoración += 100;
        CajaCachin();
    }

    public void AddPlant()
    {
        if (Evaluation_System.cont_plant_onMap <= Evaluation_System.max_plants)
        {
            Evaluation_System.cont_plant_onMap++;
            MoneySystem.cant_founds -= 90;
            Evaluation_System.b_add_plant = true;
            Evaluation_System.decoración += 15;
            CajaCachin();
        }
    }

    public void AddAlcoholEnGel()
    {
        if(Evaluation_System.cont_alcoholEnGel <= 2)
        {
            Evaluation_System.cont_alcoholEnGel++;
            MoneySystem.cant_founds -= 60;
            Evaluation_System.limpieza += 15;
            CajaCachin();
        }
    }

    public void CajaCachin()
    {
        audio_chachin.Play();
    }

}
