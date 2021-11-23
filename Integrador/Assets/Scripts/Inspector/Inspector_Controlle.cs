using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Controlle : MonoBehaviour
{
    public GameObject inspector_test;
    void Start()
    {
        inspector_test.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    public void Test()
    {
        if (Inspector.b_inspector_test == true && Store_Controller.inspector_test_done == false)
        {
            inspector_test.SetActive(true);
        }
        if (Store_Controller.inspector_test_done == true)
        {
            inspector_test.SetActive(false);
        }
    }
}
