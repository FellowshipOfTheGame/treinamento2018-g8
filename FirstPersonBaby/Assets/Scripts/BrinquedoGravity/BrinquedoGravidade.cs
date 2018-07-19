using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrinquedoGravidade : MonoBehaviour {

    Movimento ScriptMovimento;
    PickObjects Pegador;
    GameObject Jogador;
    GameObject o_camera;
    CharacterController controlador;
    
    public float graus_segundo;
    float GravidadePadrao;
    bool SegurandoBrinquedo;
    bool girando = false;
    float quantidade_girada = 0.0f;
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
        if (girando)
        {
            Jogador.transform.RotateAround(Jogador.transform.position, giro, graus_segundo*Time.deltaTime);
            quantidade_girada += graus_segundo * Time.deltaTime;
            if(quantidade_girada >= 180.0f)
            {
                girando = false;
                quantidade_girada = 0.0f;
                Jogador.GetComponent<Movimento>().enabled = true;   
                if((o_camera.transform.eulerAngles.z) < (180 - o_camera.transform.eulerAngles.z))
                {
                    Jogador.transform.RotateAround(Jogador.transform.position, giro, -o_camera.transform.eulerAngles.z);
                }
                else
                {
                    Jogador.transform.RotateAround(Jogador.transform.position, giro,(180 - o_camera.transform.eulerAngles.z));
                }
            }
        }
        else
        {
            if (SegurandoBrinquedo)
            {
                if (Input.GetButtonDown("Action"))
                {
                    Jogador.GetComponent<Movimento>().enabled = false;
                    girando = true;
                    giro = (Quaternion.AngleAxis(o_camera.transform.eulerAngles.y, Vector3.up) * Vector3.forward);
                    GravidadePadrao = -GravidadePadrao;
                    if (gameObject.GetComponent<GravidadeInvertida>() == null)
                    {
                        gameObject.AddComponent<GravidadeInvertida>();
                    }
                    else
                    {
                        Destroy(gameObject.GetComponent<GravidadeInvertida>());
                    }
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
                        if (temp.GetComponent<Rigidbody>() != null)
                        {
                            if (temp.GetComponent<GravidadeInvertida>() == null)
                            {
                                temp.AddComponent<GravidadeInvertida>();
                            }
                            else
                            {
                                Destroy(temp.GetComponent<GravidadeInvertida>());
                            }
                        }
                    }
                }
            }
            if (GravidadePadrao == -ScriptMovimento.gravidadePadrao)
            {
                controlador.Move((new Vector3(0, -GravidadePadrao, 0)) * 2 * Time.deltaTime);
            }
        }
    }
}
