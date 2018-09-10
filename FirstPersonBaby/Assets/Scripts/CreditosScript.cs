using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosScript : MonoBehaviour {

    private FalasCena DialogueMan;

    void Start() {
        DialogueMan = this.GetComponent<FalasCena>();
        DialogueMan.mostrarTexto(0);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
        }
		
	}
}
