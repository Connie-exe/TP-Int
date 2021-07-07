using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    public Text txt_vaccined;
    public Text txt_founds;
    public Text txt_supplies;

    public static int cant_founds = 1000;
    public static int cant_cured = 0;
    public static int cant_vac = 15;
    void Start()
    {
        txt_vaccined.text = "Vaccined " + cant_cured;
        txt_founds.text = "Founds: " + cant_founds;
        txt_supplies.text = "Supplies: " + cant_vac;
        cant_founds += cant_cured * 100;
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
    }
}
