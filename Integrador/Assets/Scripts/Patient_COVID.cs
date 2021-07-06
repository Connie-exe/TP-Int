using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient_COVID : MonoBehaviour
{
    public void OnMouseDown()
    {
        MoneySystem.cant_founds += 200;
        Destroy(gameObject);
    }
}
