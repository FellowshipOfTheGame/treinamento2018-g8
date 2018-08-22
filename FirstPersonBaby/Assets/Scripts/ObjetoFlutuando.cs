using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoFlutuando : MonoBehaviour {


    Vector3 OriginalPos;
    public float oscilacao = 0.2f;
    // Use this for initialization
    void Start () {
       OriginalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 NewPos = new Vector3(0.0f, OriginalPos.y + Mathf.Sin(Time.time) * oscilacao, 0.0f);
        transform.position = new Vector3(transform.position.x, NewPos.y, transform.position.z);


	}

}
