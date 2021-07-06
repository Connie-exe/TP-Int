using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Controller : MonoBehaviour
{
   public void OnCollisionEnter(Collision collision)//si collisiona con...
   {
        if (collision.gameObject.CompareTag("Patient"))//con un objeto con etiqueta Projectile
        {
            MoneySystem.cant_cured++;
            MoneySystem.cant_vac--;
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
        }
   }
}
