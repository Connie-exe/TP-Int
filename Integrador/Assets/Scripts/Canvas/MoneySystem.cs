﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    public Text txt_vaccined;
    public Text txt_founds;
    public Text txt_supplies;
    public Text txt_debt;

    public static int cant_founds;
    public static int cant_cured = 0;
    public static int cant_vac = 5;
    public static int cant_debt = 0;

    public static bool b_loan;
    void Start()
    {
        txt_vaccined.text = "Vaccined: " + cant_cured;
        txt_founds.text = "Founds: " + cant_founds;
        txt_supplies.text = "Supplies: " + cant_vac;
        txt_debt.text = "Debt: " + cant_debt;
        b_loan = false;  
        
        //if(Instructions.cont_Levels == 0)
        //{
        //    cant_founds = 1000;
        //}
        //if(Instructions.cont_Levels == 1)
        //{
        //    cant_founds = 2000;
        //}
    }
    void Update()
    {
        PrintData();
    }

    public void PrintData()
    {
        txt_vaccined.text = "Vaccined " + cant_cured;
        txt_founds.text = "Founds: " + cant_founds;
        txt_supplies.text = "Supplies: " + cant_vac;
        txt_debt.text = "Debt: " + cant_debt;
    }
}