using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Effect : MonoBehaviour
{
    public Animator camAnim;
    void Start()
    {
        
    }   
    void Update()
    {
        
    }

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }
}
