using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour {

    // Use this for initialization

    bool segurandoObj = false;
    bool podePegar = false;
    GameObject objetoAPegar;
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

        objetoAPegar.SetActive(false);


      
        

    }


    void jogarObjeto() {

        segurandoObj = false;

        objetoAPegar.SetActive(true);

        objetoAPegar.transform.position = MainCamera.transform.position + new Vector3(0,0,0.5f);

        objetoAPegar.GetComponent<Rigidbody>().AddForce(MainCamera.forward * forca, ForceMode.Impulse);

    }
    
    
    void OnTriggerEnter(Collider objeto) {

        podePegar = true;

        objetoAPegar = objeto.gameObject;


    }

    void OnTriggerExit(Collider objeto) {

        podePegar = false;

            
    }






}
