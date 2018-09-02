using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour {

    public GameObject[] objects;
    public int tipo_bolinha; //1=vermelho 2=azul
    public bool destroiAlvo = false; // true para destroir o alvo

    //Variavel para daixar um delay de ativação, para não ativar e desativar rapida em menos de 0.5 segundos. Isso é um bug que encontrei;
    private bool podeEntrar = true;

    private void OnTriggerEnter(Collider other)
    {
        if (podeEntrar) {

            if (((other.gameObject.tag == "BolinhaVermelha") && (tipo_bolinha == 1)) || ((other.gameObject.tag == "BolinhaAzul") && (tipo_bolinha == 2))) {
                int nbr = objects.Length;
                for (int i = 0; i < nbr; i++) {
                    if (objects[i].activeSelf) {
                        objects[i].SetActive(false);
                    }
                    else {
                        objects[i].SetActive(true);
                    }
                }

                if (destroiAlvo) {
                    Destroy(this.gameObject);
                }
                //Inicia o timer de 0.5f para o alvo poder ser ativado de novo
                StartCoroutine("timerDelay");

            }
        }
    }
    
    IEnumerator timerDelay() {

        podeEntrar = false;
        //Espera 0.5s para poder ativar o alvo de novo
        yield return new WaitForSeconds(0.5f);
        podeEntrar = true;
    }
}
