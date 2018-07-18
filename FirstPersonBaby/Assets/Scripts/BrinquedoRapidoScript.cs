using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrinquedoRapidoScript : MonoBehaviour
{

    bool SegurandoCarro = false;

    public GameObject Player;

    public float fast_speed = 18.0f;

    PickObjects pegador;

    private CharacterController cont;

    public float gravidadePadrao = 0.0f;

    Transform cam_tr;

    Vector3 movedirect_v = Vector3.zero;
    Vector3 movedirect = Vector3.zero;

    void Start()
    {

        cam_tr = Camera.main.transform;

        cont = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        pegador = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        if (pegador == null)
        {
            print("Player não encontrado");


        }
    }

    void Update()
    {

        SegurandoCarro = false;

        if (pegador.segurandoObj)
        {
            if (pegador.objetoAPegar == this.gameObject)
            {

                SegurandoCarro = true;
            }
        }

        if (SegurandoCarro)
        {
            {

                movedirect_v = Input.GetAxis("Action") * cam_tr.forward * fast_speed;


                movedirect = movedirect_v;

                movedirect.y = -gravidadePadrao;

                cont.Move(movedirect * Time.deltaTime);

                print(cont.isGrounded);

            }

        }
    }
}