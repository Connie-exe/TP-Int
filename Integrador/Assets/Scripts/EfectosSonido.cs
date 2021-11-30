using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosSonido : MonoBehaviour
{
    public AudioSource audio_crackRepair;

    public static bool b_repairing_crack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(b_repairing_crack == true)
        {
            audio_crackRepair.Play();
        }
        
    }
}
