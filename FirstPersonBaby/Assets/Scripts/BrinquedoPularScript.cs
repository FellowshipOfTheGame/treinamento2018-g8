using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrinquedoPularScript : MonoBehaviour {

    // Referencias a outras estruturas
    PickObjects pegador;
    CharacterController controlador;
    Movimento scritMovimento;

    //Configuração do pulo
    public float alturaSalto = 10.0f;
    float gravidadePadrao;
    public float gravidadeComBrinquedo = 2.0f;
    float velocidadeVertical;

    //Variavel verifica se o brinquedo esta ativo
    bool segurandoBrinquedoPular = false;


    //Varievel para verificar se o player esta parado;
    Vector3 PosInicial = Vector3.zero;
    Vector3 PosFinal = Vector3.zero;
    bool frame = true;



	void Start () {
        atualizarDados();
        gravidadePadrao = scritMovimento.gravidadePadrao;
    }
	
	// Update is called once per frame
	void LateUpdate () {

        segurandoBrinquedoPular = false;
        atualizarDados();


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

        //print(controlador.isGrounded);
      
        //Logica para arrumar o problema dele não pular quando esta parado
        //Basicamente verifica se o player esta em movimento ou não, quando o player esta parado ele libera o pulo
        //Se pegar a velocidade diretamente pelo o unity estava bugando, então fiz uma logica para regastar a velocidade
        PosFinal = controlador.gameObject.transform.position;
        if (frame) {
            PosInicial = controlador.gameObject.transform.position;
        }

        Vector3 velocidade = Vector3.up;

        if (!frame) {
            velocidade = PosFinal - PosInicial;
        }

        frame = !frame;

  //      print(difenca.magnitude);

        if (controlador.isGrounded || velocidade.magnitude < 0.0001f) {

//            print("entrou");

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

    void atualizarDados() {

        scritMovimento = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimento>();
        controlador = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        // pegador = AreaPickUp.GetComponent<PickObjects>();
        pegador = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        if (pegador == null) {
            print(GameObject.FindGameObjectWithTag("AreaPickUp").name);
        }

    }


}
