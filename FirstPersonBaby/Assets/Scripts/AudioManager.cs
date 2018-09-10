using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource emissor;

    //Vetor com os sons que serão tocados
    public AudioClip[] sons;

	// Use this for initialization
	void Start () {
        emissor = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    //Função para tocar um som escolhido, o parametro é a posição no vetor
    public void tocarSom(int num) {
        if (num >= 0 && num < sons.Length) {
            if (emissor.isPlaying) {
                emissor.Stop();
            }
            emissor.clip = sons[num];
            emissor.loop = false; 
            emissor.Play();
        }
    }





}
