using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSelection : MonoBehaviour
{
    public int cont = 0;
    public string name_step;
    public GameObject button;
    void Start()
    {
        name_step = button.gameObject.name;
        
    }
    void Update()
    {
        //CorrectOrder();
    }

    public void CorrectOrder()
    {
        switch (name_step)
        {
            case "wash1":
                cont = 1;
                break;
            case "wash2":
                if(cont == 1)
                {
                    cont = 2;
                }                
                break;
            case "wash3":
                if (cont == 2)
                {
                    cont = 3;
                }
                break;
            case "wash4":
                if (cont == 3)
                {
                    cont = 4;
                }
                break;
            case "wash5":
                if (cont == 4)
                {
                    cont = 5;
                }
                break;
            case "wash6":
                if (cont == 5)
                {
                    cont = 6;
                }
                break;
            default:
                if (cont == 6)
                {
                    cont = 7;
                }
                break;
        }
    }

}
