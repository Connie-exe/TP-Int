using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Controlle : MonoBehaviour
{
    public GameObject inspector_test;
    public GameObject[] objs;
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
        //objs = GameObject.FindGameObjectsWithTag("Preguntas");
        if (Inspector.b_inspector_test == true && Store_Controller.inspector_test_done == false)
        {
            inspector_test.SetActive(true);
            switch (Inspector.q_selected)
            {
                case 1:                    
                    objs[0].SetActive(true);
                    break;
                case 2:
                    objs[1].SetActive(true);
                    break;
                //case 3:
                //    objs[2].SetActive(true);
                //    break;
                default:
                    objs[2].SetActive(true);
                    break;
            }
        }
        if (Store_Controller.inspector_test_done == true)
        {
            StartCoroutine(PanelTime());
        }
    }

    IEnumerator PanelTime()
    {
        yield return new WaitForSeconds(3f);
        inspector_test.SetActive(false);
    }
}
