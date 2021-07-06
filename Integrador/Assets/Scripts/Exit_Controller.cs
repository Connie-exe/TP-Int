using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Controller : MonoBehaviour
{
   public void OnCollisionEnter(Collision collision)//si collisiona con...
   {
        if (collision.gameObject.CompareTag("Patient"))//con un objeto con etiqueta Projectile
        {
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
        }
   }
}
