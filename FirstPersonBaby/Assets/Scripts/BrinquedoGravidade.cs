using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrinquedoGravidade : MonoBehaviour {

    Movimento ScriptMovimento;
    PickObjects Pegador;
    GameObject Jogador;
    GameObject o_camera;
    Camera c_camera;
    CharacterController controlador;

    float movimento_camera = 0.2f;
    float GravidadePadrao;
    bool SegurandoBrinquedo;
    bool Ativado = false;

    void Gira_player()
    {
        
    }

	// Use this for initialization
	void Start () {
        Jogador = GameObject.FindGameObjectWithTag("Player");
        o_camera = Jogador.transform.Find("Main Camera").gameObject;
        ScriptMovimento = Jogador.GetComponent<Movimento>();
        Pegador = Jogador.transform.Find("Main Camera").transform.Find("PickUpArea").GetComponent<PickObjects>();
        controlador = Jogador.GetComponent<CharacterController>();
        c_camera = Camera.main;

        GravidadePadrao = ScriptMovimento.gravidadePadrao;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if(Jogador == null)
        {
            print("alalalalalalalalal");
        }
        if (Pegador.segurandoObj)
        {
            if (Pegador.objetoAPegar == this.gameObject)
            {
                SegurandoBrinquedo = true;
            }
            else
            {
                SegurandoBrinquedo = false;
            }
        }
        else
        {
            SegurandoBrinquedo = false;
        }

        if (SegurandoBrinquedo)
        {
            if (Input.GetButtonDown("Action"))
            {
                GravidadePadrao = -GravidadePadrao;
                Jogador.transform.Rotate(0, 0, 180);
                o_camera.transform.Translate(new Vector3(0, movimento_camera, 0), Space.World);
                Ativado = !Ativado;
            }
            if (GravidadePadrao == -ScriptMovimento.gravidadePadrao)
            {
                controlador.Move((new Vector3(0, -GravidadePadrao, 0)) * 2 * Time.deltaTime);
            }
        }
        if(Ativado && Input.GetButtonDown("Fire1"))
        {
            GravidadePadrao = -GravidadePadrao;
            Jogador.transform.Rotate(0, 0, 180);
            o_camera.transform.Translate(new Vector3(0, movimento_camera, 0), Space.World);
            Ativado = !Ativado;
        }
	}
}
