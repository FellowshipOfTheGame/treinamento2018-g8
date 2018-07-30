using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleRobo : MonoBehaviour {

    //Varievais usadas na lógica local
    bool segurandoControleRemoto = false;
    bool usandoRobo = false;
    bool transitionIsRunning = false;

    //Cameras usadas na troca- Depois implementar a coleta automatica por script
    public GameObject Player;
    public GameObject BrinquedoRobo;
    public GameObject PlayerMesh;
    public GameObject BrinquedoRoboMesh;

    // Velocidade de transição da camera;
    public float velocidadeTransition = 1.0f;

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
            if (Input.GetButtonDown("Fire2") && !transitionIsRunning) {
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
            BrinquedoRoboMesh.transform.forward = BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.transform.forward;
            BrinquedoRoboMesh.SetActive(true);

           

        }
        else {
            //inicia a rotina de transição
            StartCoroutine("transitarAnimation");
        }
    }

    

    IEnumerator transitarAnimation() {

        usandoRobo = true;
        transitionIsRunning = true;

        //Ativar a mesh aparente;
        PlayerMesh.transform.position = Player.transform.position + new Vector3(0.5f, -1.376f, 1.5f);
        PlayerMesh.transform.forward = Player.GetComponentInChildren<Camera>().gameObject.transform.forward;
        PlayerMesh.SetActive(true);
        
        //Logica de animação de transição 
        GameObject CameraPlayer = Player.GetComponentInChildren<Camera>().gameObject;

        Vector3 PosInicialAretornar = CameraPlayer.transform.position;
        Quaternion RotInicialAretornar = CameraPlayer.transform.rotation;

        Vector3 posInicial = PosInicialAretornar;
        Vector3 posFinal = BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.transform.position;
        Quaternion rotInicial = RotInicialAretornar;
        Quaternion rotFinal = BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.transform.rotation;
  
        int x;
        // Transição dura 2 segundos , roda 20 vezes de 0.05 segundo
        for(x = 0; x < 120; x++) {
            CameraPlayer.transform.position = Vector3.Lerp(posInicial, posFinal, velocidadeTransition * Time.deltaTime);
            CameraPlayer.transform.rotation = Quaternion.Lerp(rotInicial, rotFinal, velocidadeTransition * Time.deltaTime);
            posInicial = CameraPlayer.transform.position;
            rotInicial = CameraPlayer.transform.rotation;

            if (Vector3.Distance(posInicial, posFinal) < 0.05f) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        
        //Setando Meshes
        Player.SetActive(false);
        //Volta a camera ao estado inicial
        Player.GetComponentInChildren<Camera>().gameObject.transform.position = PosInicialAretornar;
        Player.GetComponentInChildren<Camera>().gameObject.transform.rotation = RotInicialAretornar;
        // Faz o resto das configurações
        BrinquedoRobo.SetActive(true);
        BrinquedoRoboMesh.SetActive(false);
     
        transitionIsRunning = false;
    }



}
