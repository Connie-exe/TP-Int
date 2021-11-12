using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Controller : MonoBehaviour
{
   public void OnCollisionEnter(Collision collision)//si collisiona con...
   {
        if (collision.gameObject.CompareTag("Patient"))//con un objeto con etiqueta Projectile
        {
            if(MoneySystem.cant_vac > 0 && Patient_Controller.b_vaccined == true)
            {
                MoneySystem.cant_cured++;
                MoneySystem.cant_vac--;
                MoneySystem.cant_founds += 100;
            }
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
        }
        if (collision.gameObject.CompareTag("COVID_Patient"))//con un objeto con etiqueta Projectile
        {
            if (MoneySystem.cant_founds >= 100)
            {
                MoneySystem.cant_founds -= 100;
            }
            COVID_Counter.cont--;
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
        }
    }
}
