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
    Rigidbody rb;

    float movimento_camera = 0.2f;
    float GravidadePadrao;
    bool SegurandoBrinquedo;
    Vector3 giro;

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
        rb = GetComponent<Rigidbody>();

        GravidadePadrao = ScriptMovimento.gravidadePadrao;
    }
	
	// Update is called once per frame
	void LateUpdate () {
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
                giro = new Vector3(0, 0, 1);
                print(o_camera.transform.eulerAngles.y);
                giro = (Quaternion.AngleAxis(o_camera.transform.eulerAngles.y, Vector3.up) * giro);
                print(giro);
                GravidadePadrao = -GravidadePadrao;
                Jogador.transform.RotateAround(Jogador.transform.position, giro, 180);
            }
        }
        if (GravidadePadrao == -ScriptMovimento.gravidadePadrao)
        {
            controlador.Move((new Vector3(0, -GravidadePadrao, 0)) * 2 * Time.deltaTime);
        }
    }
}
