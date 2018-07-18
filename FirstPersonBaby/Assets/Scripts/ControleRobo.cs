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
            BrinquedoRobo.SetActive(false);
            Player.SetActive(true);


            //Setando Meshes
            PlayerMesh.SetActive(false);
            BrinquedoRoboMesh.transform.position = BrinquedoRobo.transform.position;
            BrinquedoRoboMesh.SetActive(true);

        }
        else {
            usandoRobo = true;
            Player.SetActive(false);
            BrinquedoRobo.SetActive(true);

            //Setando Meshes
            BrinquedoRoboMesh.SetActive(false);
            PlayerMesh.transform.position = Player.transform.position + new Vector3(0.5f, -1.376f, 1.5f);
            PlayerMesh.SetActive(true);
            // Tem um fator de correção da importação da budega, so arrumar a mesh no blender depois se quiser
        }
    }


}
