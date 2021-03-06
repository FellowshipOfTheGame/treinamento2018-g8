﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour {

    // Efeito Sonoro
    AudioManager emissor;


    [HideInInspector]
    public bool segurandoObj = false;
    bool podePegar = false;

    [HideInInspector]
    public GameObject objetoAPegar;

    Transform MainCamera;
    public float forca = 1.0f;

    // Estrutura de dados para armazenar os objetos, será escolhido o objeto mais proximo do player

    ArrayList objetosAlcance;

    UI ui;


    void Start() {
        ui = GameObject.Find("Canvas").transform.Find("BrinquedoPego").GetComponent<UI>();
        MainCamera = Camera.main.transform;
        objetosAlcance = new ArrayList();
        //Efeito sonoro
        emissor = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetButtonDown("Fire1")) {
            if (!segurandoObj) {

                DefinirSePodePegar();
                if (podePegar) {   
                    
                    DefinirObjetoApegar();
                    pegarObjeto();
                    ui.Trocar_icone();                                        
                }

            }else {
                jogarObjeto();
                //Som de jogar objeto
                emissor.tocarSom(7);
                ui.Trocar_icone();
            }
        }
       
    }

    void pegarObjeto() {

        segurandoObj = true;
        objetoAPegar.GetComponent<Collider>().enabled = false;
        objetoAPegar.GetComponent<Renderer>().enabled = false;
        objetoAPegar.GetComponent<Rigidbody>().isKinematic = true;

    }


    void jogarObjeto() {

        segurandoObj = false;

        objetoAPegar.GetComponent<Rigidbody>().isKinematic = false;
        objetoAPegar.GetComponent<Collider>().enabled = true;
        objetoAPegar.GetComponent<Renderer>().enabled = true;
 
        objetoAPegar.transform.position = MainCamera.transform.position + 0.5f*MainCamera.forward;   
        objetoAPegar.GetComponent<Rigidbody>().AddForce(MainCamera.forward * forca, ForceMode.Impulse);
       
    }

    void OnTriggerEnter(Collider objeto) {

        if(objeto.gameObject.tag != "Player") {

            if (!objetosAlcance.Contains(objeto.gameObject)) {
                objetosAlcance.Add(objeto.gameObject);
            }      
        }

    }

    void OnTriggerExit(Collider objeto) {

        if (objetosAlcance.Contains(objeto.gameObject)) {

            objetosAlcance.Remove(objeto.gameObject);
        }

        if(objetosAlcance.Count == 0) {
            podePegar = false;
        }
        
    }

    void DefinirObjetoApegar() {

        GameObject maisPerto = null;
        float menorDistancia = 1000.0f;// Gambiarra, arrumar depois (kkkkkkkkkkkk)

        foreach(GameObject x in objetosAlcance) {
            if(x != null) {

                float distancia = Vector3.Distance(this.transform.position, x.transform.position);

                if ( distancia < menorDistancia) {
                    menorDistancia = distancia;
                    maisPerto = x;
                }

            }    
        }

        if(maisPerto != null) {
            objetosAlcance.Remove(maisPerto);
            objetoAPegar = maisPerto;
        }
    
    }

    void DefinirSePodePegar() {

        podePegar = false;

        if(objetosAlcance.Count != 0) {
            if (!segurandoObj) {
                podePegar = true;
            }
        }

    }



}



