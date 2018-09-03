using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleRobo : MonoBehaviour {

    //Referencias para o som
    AudioManager emissor;

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
    //Desligar o movimento na transição
    private Movimento movimentoPlayer;
    private Movimento movimentoRobo;
    private CameraScript movimentoCameraPlayer;
    private CameraScript movimentoCameraRobo;


    void Start () {

        pegador = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        if (pegador == null) {
            print("Player não encontrado");
        }

        movimentoPlayer = Player.GetComponent<Movimento>();
        movimentoRobo = BrinquedoRobo.GetComponent<Movimento>();

        movimentoCameraPlayer = BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.GetComponent<CameraScript>();
        movimentoCameraRobo = Player.GetComponentInChildren<Camera>().gameObject.GetComponent<CameraScript>();

        emissor = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<AudioManager>();

    }
	
	
	void Update () {

        segurandoControleRemoto = false;
        //Cancela o movimento durante a transição
        if (transitionIsRunning) {
            movimentoPlayer.enabled = false;
            movimentoRobo.enabled = false;
            movimentoCameraRobo.enabled = false;
            movimentoCameraPlayer.enabled = false;
        }
        else {
            movimentoPlayer.enabled = true;
            movimentoRobo.enabled = true;
            movimentoCameraRobo.enabled = true;
            movimentoCameraPlayer.enabled = true;
        }

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
            //inicia a rotina de transição2         
            if (BrinquedoRobo.GetComponent<CharacterController>().isGrounded) {
                StartCoroutine("trasintarAnimation2");
                emissor.tocarSom(6);
            }                          
        }
        else {
            //inicia a rotina de transição
            StartCoroutine("transitarAnimation");
            emissor.tocarSom(6);
        }
    }

    
    IEnumerator trasintarAnimation2() {
        
        usandoRobo = false;
        transitionIsRunning = true;

        //Desliga o colider para não bugar , será religado ao final da transição
        BrinquedoRoboMesh.GetComponent<Collider>().enabled = false;

        BrinquedoRoboMesh.transform.position = BrinquedoRobo.transform.position;
        BrinquedoRoboMesh.transform.forward = BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.transform.forward;
        BrinquedoRoboMesh.SetActive(true);

        //Logica de animação de transição 
        GameObject CameraPlayer = BrinquedoRobo.GetComponentInChildren<Camera>().gameObject;

        Vector3 PosInicialAretornar = CameraPlayer.transform.position;
        Quaternion RotInicialAretornar = CameraPlayer.transform.rotation;

        Vector3 posInicial = PosInicialAretornar;
        Vector3 posFinal = Player.GetComponentInChildren<Camera>().gameObject.transform.position;
        Quaternion rotInicial = RotInicialAretornar;
        Quaternion rotFinal = Player.GetComponentInChildren<Camera>().gameObject.transform.rotation;

        int x;
        // Transição dura 2 segundos , roda 20 vezes de 0.05 segundo
        for (x = 0; x < 120; x++) {
            CameraPlayer.transform.position = Vector3.Lerp(posInicial, posFinal, velocidadeTransition * Time.deltaTime);
            CameraPlayer.transform.rotation = Quaternion.Lerp(rotInicial, rotFinal, velocidadeTransition * Time.deltaTime);
            posInicial = CameraPlayer.transform.position;
            rotInicial = CameraPlayer.transform.rotation;

            if (Vector3.Distance(posInicial, posFinal) < 0.05f) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }

        //Faz as configurações necessarias
        BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.transform.position = PosInicialAretornar;
        BrinquedoRobo.GetComponentInChildren<Camera>().gameObject.transform.rotation = RotInicialAretornar;


        PlayerMesh.SetActive(false);
        BrinquedoRobo.SetActive(false);
        Player.SetActive(true);
        //Volta a camera
      
        // Fim da coroutine
        transitionIsRunning = false;

        BrinquedoRoboMesh.GetComponent<Collider>().enabled = true;
    }


    IEnumerator transitarAnimation() {

        usandoRobo = true;
        transitionIsRunning = true;

        //Desliga o colider para não bugar , será religado ao final da transição
        //PlayerMesh.GetComponentInChildren<Collider>().enabled = false;

        //Ativar a mesh aparente;
        PlayerMesh.transform.position = Player.transform.position;
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
        
        //Volta a camera ao estado inicial
        Player.GetComponentInChildren<Camera>().gameObject.transform.position = PosInicialAretornar;
        Player.GetComponentInChildren<Camera>().gameObject.transform.rotation = RotInicialAretornar;
        // Faz o resto das configurações
        Player.SetActive(false);
        BrinquedoRoboMesh.SetActive(false);
        BrinquedoRobo.SetActive(true);

        //PlayerMesh.GetComponentInChildren<Collider>().enabled = true;
        //Fim da coroutine
        transitionIsRunning = false;
    }


}
