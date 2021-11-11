using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediciónSintomas : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
        rb.isKinematic = true;
    }
}
