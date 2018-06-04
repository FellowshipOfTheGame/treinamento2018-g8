using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {


    public float speedFrente = 1.0f;

    public float speedLado = 1.0f;

    private CharacterController cont;

    public float gravidadePadrao = 5.0f;

    Transform cam_tr;

    Vector3 movedirect_v = Vector3.zero;
    Vector3 movedirect_h = Vector3.zero;
    Vector3 movedirect = Vector3.zero;

    void Start() {

        cam_tr = Camera.main.transform;

        cont = GetComponent<CharacterController>();

    }

    void Update() {

        movedirect_v = Input.GetAxis("Vertical") * cam_tr.forward * speedFrente;

        movedirect_h = Input.GetAxis("Horizontal") * cam_tr.right * speedLado;

        movedirect = movedirect_h + movedirect_v;

       // movedirect = movedirect.normalized;

    

        movedirect.y = -gravidadePadrao;

        cont.Move(movedirect * Time.deltaTime);

        print(cont.isGrounded);

    }



}
