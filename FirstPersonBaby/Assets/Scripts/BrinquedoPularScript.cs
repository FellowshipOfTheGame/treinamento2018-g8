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

    Movimento scritMovimento;

	void Start () {


        scritMovimento = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimento>();

        gravidadePadrao = scritMovimento.gravidadePadrao;

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
        }else {
            scritMovimento.gravidadePadrao = gravidadePadrao;

        }

        


    }

    public float controladorPulo() {

         print(controlador.isGrounded);

   

        if (controlador.isGrounded) {

            if (velocidadeVertical < 0) {
                velocidadeVertical = 0;
                scritMovimento.gravidadePadrao = gravidadePadrao;
            }
            

            if (Input.GetButtonDown("Action")) {

                 velocidadeVertical = alturaSalto;
                scritMovimento.gravidadePadrao = 0;
            }

        }
        else {

            scritMovimento.gravidadePadrao = 0;
            velocidadeVertical = velocidadeVertical - (gravidadeComBrinquedo * Time.deltaTime);
  
        }

        return velocidadeVertical * Time.deltaTime;

        //  controlador.Move(new Vector3(0, velocidadeVertical * Time.deltaTime, 0));


    }





}
