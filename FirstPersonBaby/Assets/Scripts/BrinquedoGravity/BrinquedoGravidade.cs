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
                giro = (Quaternion.AngleAxis(o_camera.transform.eulerAngles.y, Vector3.up) * Vector3.forward);
                GravidadePadrao = -GravidadePadrao;
                Jogador.transform.RotateAround(Jogador.transform.position, giro, 180);
            }
            if (Input.GetButtonDown("Action2"))
            {
                float dist = 0.77f;
                Vector3 dir = Quaternion.Euler(o_camera.transform.eulerAngles) * Vector3.forward;
                Ray look = new Ray((o_camera.transform.position + dir.normalized * dist), dir);
                RaycastHit info = new RaycastHit();
                if (Physics.Raycast(look, out info))
                {
                    GameObject temp = info.collider.gameObject;
                    print(temp.name);
                }
            }
        }
        if (GravidadePadrao == -ScriptMovimento.gravidadePadrao)
        {
            controlador.Move((new Vector3(0, -GravidadePadrao, 0)) * 2 * Time.deltaTime);
        }
    }
}
