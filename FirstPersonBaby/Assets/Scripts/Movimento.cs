using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {

    public float speed = 1.0f;

    private CharacterController cont;

    Transform cam_tr;



    Vector3 movedirect = Vector3.zero;



    // Use this for initialization

    void Start() {

        cam_tr = Camera.main.transform;

       cont = GetComponent<CharacterController>();

    }



    // Update is called once per frame

    void Update() {

        movedirect = cam_tr.forward;

        movedirect = movedirect * speed * Input.GetAxis("Vertical");

        cont.Move(movedirect * Time.deltaTime);

    }


}
