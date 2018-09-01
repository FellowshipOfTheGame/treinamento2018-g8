using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarFala : MonoBehaviour {

    //Variaveis internas
    private bool JaUsado = false;
    //Usar o mesh para ver se o brinquedo esta ou não sendo usado
    private Renderer mesh;
    private FalasCena DialogueMan;

    //Variaves Configuradas
    public int NumeroFala = 0;

	// Use this for initialization
	void Start () {
        mesh = this.GetComponent<Renderer>();
        DialogueMan = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<FalasCena>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!JaUsado) {
            if (mesh.enabled == false) {
                JaUsado = true;
                DialogueMan.mostrarTexto(NumeroFala);
            }
        }
	}
}
