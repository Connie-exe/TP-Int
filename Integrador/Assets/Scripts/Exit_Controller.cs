using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Controller : MonoBehaviour
{
   public void OnCollisionEnter(Collision collision)//si collisiona con...
   {
        if (collision.gameObject.CompareTag("Patient"))//con un objeto con etiqueta Projectile
        {
            if(MoneySystem.cant_vac > 0)
            {
                MoneySystem.cant_cured++;
                MoneySystem.cant_vac--;
            }
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
        }
        if (collision.gameObject.CompareTag("COVID_Patient"))//con un objeto con etiqueta Projectile
        {
            if (MoneySystem.cant_founds >= 100)
            {
                MoneySystem.cant_founds -= 100;
                MoneySystem.cant_vac--;
            }
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
        }
    }
}
