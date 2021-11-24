using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack_Controller : MonoBehaviour
{
    public static int cont_damage;    
    private void Start()
    {
        cont_damage = Earthquake_Controller.cant_damageSpots;
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if(MoneySystem.cant_founds >= 500)
        {
            MoneySystem.cant_founds -= 500;
            cont_damage--;            
            Destroy(gameObject);
            Evaluation_System.seguridad += 100;
            Evaluation_System.decoración += 40;
        }
    }
}
