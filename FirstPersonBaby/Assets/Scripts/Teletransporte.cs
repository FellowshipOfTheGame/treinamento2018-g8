using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teletransporte : MonoBehaviour {

    public Animator transition;
    
    public string cena;

    void OnTriggerEnter(Collider brinquedo) {

        if (brinquedo.gameObject.tag == "Player") {
            //SceneManager.LoadScene(cena);
            transition.SetTrigger("FadeOut");
            return;
        }
        if(brinquedo.gameObject.tag == "AreaPickUp") {
            return;
        }

        brinquedo.gameObject.SetActive(false);
    }

}
