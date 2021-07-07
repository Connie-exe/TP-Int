using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Controller : MonoBehaviour
{
    
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
}
