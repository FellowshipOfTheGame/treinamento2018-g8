using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour {

    public GameObject[] objects;
    public int tipo_bolinha; //1=vermelho 2=azul
    public bool destroiAlvo = false; // true para destroir o alvo

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(((other.gameObject.tag == "BolinhaVermelha")&&(tipo_bolinha == 1)) || ((other.gameObject.tag == "BolinhaAzul") && (tipo_bolinha == 2))){ 
            int nbr = objects.Length;
            for (int i = 0; i < nbr; i++)
            {
                if (objects[i].activeSelf)
                {
                    objects[i].SetActive(false);
                } else
                {
                    objects[i].SetActive(true);
                }
            }

            if (destroiAlvo) {
                Destroy(this.gameObject);
            }

        }

    }
}



