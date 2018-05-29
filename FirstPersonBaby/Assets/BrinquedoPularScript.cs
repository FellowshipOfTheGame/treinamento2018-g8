using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrinquedoPularScript : MonoBehaviour {

    public GameObject AreaPickUp;

    PickObjects pegador;

    CharacterController controlador;

    public float alturaSalto = 10.0f;

    float gravidadePadrao;

    public float gravidadeComBrinquedo = 2.0f;

    float velocidadeVertical;

    bool segurandoBrinquedoPular = false;
	

	void Start () {

        gravidadePadrao = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimento>().gravidadePadrao;

        controlador = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        pegador = AreaPickUp.GetComponent<PickObjects>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        segurandoBrinquedoPular = false;

        if (pegador.segurandoObj) {

            if (pegador.objetoAPegar == this.gameObject) {

                segurandoBrinquedoPular = true;

            }
        }

        if (segurandoBrinquedoPular) {

            controlador.Move(new Vector3(0, controladorPulo(), 0));
        }
       


    }

    public float controladorPulo() {

        // print(controlador.isGrounded);


        if (controlador.isGrounded) {

            velocidadeVertical = -gravidadePadrao * Time.deltaTime;

            if (Input.GetButtonDown("Action")) {

                if (segurandoBrinquedoPular) {

                    velocidadeVertical = alturaSalto;
                }
            }

        }
        else {

            if (segurandoBrinquedoPular) {

                velocidadeVertical = velocidadeVertical - (gravidadeComBrinquedo * Time.deltaTime);
            }
            else {

                velocidadeVertical = velocidadeVertical - (gravidadePadrao * Time.deltaTime);
            }

        }

        return velocidadeVertical * Time.deltaTime;

        //  controlador.Move(new Vector3(0, velocidadeVertical * Time.deltaTime, 0));


    }





}
