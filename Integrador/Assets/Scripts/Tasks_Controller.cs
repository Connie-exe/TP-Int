using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks_Controller : MonoBehaviour
{
    public Toggle tg_cured;
    public Toggle tg_founds;
    public Toggle tg_debt;
    public Toggle tg_cracks;

    public void Update()
    {
        Cured_Toggle();
        Founds_Toggle();
        Debt_Toggle();
        Crack_Toggle();
    }
    public void Cured_Toggle()
    {
        if(MoneySystem.cant_cured == 1)
        {
            tg_cured.isOn = true;
        }
        else
        {
            tg_cured.isOn = false;
        }
    }

    public void Founds_Toggle()
    {
        if (MoneySystem.cant_founds >= 1000)
        {
            tg_founds.isOn = true;
        }
        else
        {
            tg_founds.isOn = false;
        }
    }

    public void Debt_Toggle()
    {
        if(MoneySystem.b_loan == false)
        {
            tg_debt.isOn = true;
        }
        else
        {
            tg_debt.isOn = false;
        }
    }

    public void Crack_Toggle()
    {
        if(Crack_Controller.cont_damage <= 0)
        {
            tg_cracks.isOn = true;
        }
        else
        {
            tg_cracks.isOn = false;
        }
    }
}
