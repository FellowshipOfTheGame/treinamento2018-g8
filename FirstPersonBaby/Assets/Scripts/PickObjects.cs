using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour {

    // Use this for initialization

    [HideInInspector]
    public bool segurandoObj = false;
    bool podePegar = false;

    [HideInInspector]
    public GameObject objetoAPegar;

    Transform MainCamera;
    public float forca = 1.0f;

    void Start() {

        MainCamera = Camera.main.transform;

    }

    // Update is called once per frame
    void Update() {

        if(Input.GetButtonDown("Fire1")) {

            if (!segurandoObj) {

                if (podePegar) {

                   
                        pegarObjeto();
                    
                        

                }

            }else {

                jogarObjeto();


            }
        }
       
    }

    void pegarObjeto() {

        segurandoObj = true;

       // objetoAPegar.SetActive(false);

        objetoAPegar.GetComponent<Collider>().enabled = false;
        objetoAPegar.GetComponent<Renderer>().enabled = false;

        objetoAPegar.GetComponent<Rigidbody>().isKinematic = true;

    }


    void jogarObjeto() {

        segurandoObj = false;

        //objetoAPegar.SetActive(true);

        objetoAPegar.GetComponent<Rigidbody>().isKinematic = false;

        objetoAPegar.GetComponent<Collider>().enabled = true;
        objetoAPegar.GetComponent<Renderer>().enabled = true;


        objetoAPegar.transform.position = MainCamera.transform.position + MainCamera.forward;

        objetoAPegar.GetComponent<Rigidbody>().AddForce(MainCamera.forward * forca, ForceMode.Impulse);


    }
    
    
    void OnTriggerEnter(Collider objeto) {

        if(objeto.gameObject.tag != "Player") {

            if (!segurandoObj) {

                objetoAPegar = objeto.gameObject;
                podePegar = true;

            }
       
        }


    }

    void OnTriggerExit(Collider objeto) {

        podePegar = false;

            
    }






}
