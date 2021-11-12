using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameObject : MonoBehaviour
{
    public GameObject im_clock;

    // Update is called once per frame
    void Update()
    {
        Vector3 imagePos = Camera.main.WorldToScreenPoint(this.transform.position);
        im_clock.transform.position = imagePos;
    }
}
