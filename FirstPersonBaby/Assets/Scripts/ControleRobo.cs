using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleRobo : MonoBehaviour {

    //Varievais usadas na lógica local
    bool segurandoControleRemoto = false;
    bool usandoRobo = false;

    //Cameras usadas na troca- Depois implementar a coleta automatica por script
    public GameObject Player;
    public GameObject BrinquedoRobo;
    public GameObject PlayerMesh;
    public GameObject BrinquedoRoboMesh;

    //Referencias a outros scripts 
    PickObjects pegador;

    void Start () {

        pegador = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        if (pegador == null) {
            print("Player não encontrado");
        }

    }
	
	
	void Update () {
  
        segurandoControleRemoto = false;

        if (pegador.segurandoObj) {
            if (pegador.objetoAPegar == this.gameObject) {
 
                segurandoControleRemoto = true;
            }
        }

        if (segurandoControleRemoto) {
            if (Input.GetButtonDown("Fire2")) {

                transitarRobo();

            }
        }

    }

    void transitarRobo() {

        if (usandoRobo) {
            usandoRobo = false;
            Player.SetActive(true);
            BrinquedoRobo.SetActive(false);

            //Setando Meshes
            BrinquedoRoboMesh.transform.position = BrinquedoRobo.transform.position;
            BrinquedoRoboMesh.SetActive(true);
            PlayerMesh.SetActive(false);
 

           // BrinquedoRobo.transform.Find("BrinquedoRobo").gameObject.SetActive(false);
            //Troca de Cameras
            //Player.GetComponentInChildren<Camera>().enabled = true;
            //BrinquedoRobo.GetComponentInChildren<Camera>().enabled = false;
            //Desliga/Liga o movimento
           // Player.GetComponent<Movimento>().enabled = false;
            //BrinquedoRobo.GetComponent<Movimento>().enabled = true;
            // Desliga/Liga As areas de coleta de itens
            //Player.transform.Find("PickUpArea").gameObject.SetActive(true);
            //BrinquedoRobo.transform.Find("PickUpArea").gameObject.SetActive(false);  
        }
        else {
            usandoRobo = true;
            BrinquedoRobo.SetActive(true);
            Player.SetActive(false);

            //Setando Meshes
            PlayerMesh.transform.position = Player.transform.position + new Vector3(1.479855f, -1.376f, -0.04f);
            PlayerMesh.SetActive(true);
            // Tem um fator de correção da importação da budega, so arrumar a mesh no blender depois se quiser
            
            BrinquedoRoboMesh.SetActive(false);
        
            // BrinquedoRobo.transform.Find("BrinquedoRobo").gameObject.SetActive(true);
            //Troca de Cameras
            //Player.GetComponentInChildren<Camera>().enabled = false;
            //BrinquedoRobo.GetComponentInChildren<Camera>().enabled = true;
            //Desliga o movimento
            //Player.GetComponent<Movimento>().enabled = false;
            //BrinquedoRobo.GetComponent<Movimento>().enabled = true;
            //Desliga/Liga as areas de coleta de itens
            //Player.transform.Find("PickUpArea").gameObject.SetActive(false);
            //BrinquedoRobo.transform.Find("PickUpArea").gameObject.SetActive(true);
        }
    }


}
