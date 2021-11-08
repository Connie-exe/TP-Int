using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSelection : MonoBehaviour
{
    public Image fillimage;
    //public GameObject[] buttons;
    public int cont = 0;
    //public float timer;
    //private float waitTime;
    void Start()
    {
        fillimage.fillAmount = 0;
    }
    void Update()
    {
        SelectStep();
    }

    public void SelectStep()
    {
        //if (name == "btn_WashHands1")
        //{
        //    fillimage.fillAmount += 2;
        //    cont++;
        //}
        switch (cont)
        {

            case 0:
                if (name == "btn_WashHands1")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
            case 1:
                if (this.name == "btn_WashHands2")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
            case 2:
                if (this.name == "btn_WashHands3")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
            case 3:
                if (this.name == "btn_WashHands4")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
            case 4:
                if (this.name == "btn_WashHands5")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
            case 5:
                if (this.name == "btn_WashHands6")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
            case 6:
                if (this.name == "btn_WashHands7")
                {
                    fillimage.fillAmount += 2;
                    cont++;
                }
                break;
        }
        
    }
}
