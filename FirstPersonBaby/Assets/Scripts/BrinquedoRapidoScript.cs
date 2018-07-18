using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrinquedoRapidoScript : MonoBehaviour {

    public float fast_speed = 1.0f;

    private CharacterController cont;

    public float gravidadePadrao = 5.0f;

    Transform cam_tr;

    Vector3 movedirect_v = Vector3.zero;
    Vector3 movedirect = Vector3.zero;

    void Start()
    {

        cam_tr = Camera.main.transform;

        cont = GetComponent<CharacterController>();

    }

    void Update()
    {

        movedirect_v = Input.GetAxis("superv") * cam_tr.forward * fast_speed;
 

        movedirect = movedirect_v;

        movedirect.y = -gravidadePadrao;

        cont.Move(movedirect * Time.deltaTime);

        print(cont.isGrounded);

    }
}