using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    public string str_link;    
    void Update()
    {
        ButtonLink(str_link);
    }

    public void ButtonLink(string enlace)
    {
        Application.OpenURL(enlace);
    }
}
