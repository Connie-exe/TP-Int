using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack_Controller : MonoBehaviour
{
    public static int cont_damage;
    public AudioSource audio_crackRepair;
    public Renderer rend;
    private void Start()
    {
        cont_damage = Earthquake_Controller.cant_damageSpots;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        rend.enabled = false;
        audio_crackRepair.Play();
        MoneySystem.cant_founds -= 500;
        cont_damage--;            
        Destroy(this.gameObject, audio_crackRepair.clip.length);
        Evaluation_System.seguridad += 100;
        Evaluation_System.decoración += 40;            
    }
}
