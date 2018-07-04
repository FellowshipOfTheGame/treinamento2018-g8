using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerNuvens : MonoBehaviour {

    public GameObject PickUpArea;
    public PickObjects pc;

   private void Start()
    {
        pc = PickUpArea.GetComponent<PickObjects>();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {
        if(pc.segurandoObj == true)
        {
           gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
           gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
