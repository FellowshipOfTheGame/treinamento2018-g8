using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerPortalHub : MonoBehaviour {

    public GameObject[] objetosAparecer;
    private Renderer mesh;
    private bool JaUsado = false;
    // Use this for initialization
    void Start () {
        mesh = this.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!JaUsado) {
            if (mesh.enabled == false) {
                JaUsado = true;
                LigarObjetos();
            }
        }
	}

    void LigarObjetos() {
        for(int x = 0; x < objetosAparecer.Length ; x++) {
            objetosAparecer[x].SetActive(true);
        }
    }
}
