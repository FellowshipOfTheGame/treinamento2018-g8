using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFala : MonoBehaviour {

    //Variaveis internas
    private bool JaUsado = false;
    private FalasCena DialogueMan;

    //Variaveis configuraveis
    public int NumeroFala = 0;

    // Use this for initialization
    void Start () {
		DialogueMan = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<FalasCena>();
    }

    private void OnTriggerEnter(Collider other) {
        if (!JaUsado) {
            if (other.gameObject.CompareTag("Player")) {
                JaUsado = true;
                DialogueMan.mostrarTexto(NumeroFala);
            }
        }      
    }


}
