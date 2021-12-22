using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Test : MonoBehaviour
{
    public GameObject im_correct;
    public GameObject im_false;
    private void OnMouseDown()
    {
        if (this.gameObject.tag == "Correct")
        {
            im_correct.SetActive(true);            
            //Store_Controller.inspector_test_done = true;
        }
        if(this.gameObject.tag == "False")
        {
            im_false.SetActive(true);
            //Store_Controller.inspector_test_done = true;
        }
    }

}
