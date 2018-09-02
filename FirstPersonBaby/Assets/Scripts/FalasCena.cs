﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalasCena : MonoBehaviour {

    //Variaveis internas
    private Text textoBalao;
    private bool isShowingText = false;    

    //Pega o balao como parametro
    public GameObject BalaoFalas;

    //Variaveis configuraveis
    public float tempoDeDurar = 2.0f;
    public float velocidadeAparecer = 0.1f;

    //Classe que será utilizada para armazenar as falar
    [TextArea(3,10)]
    public string[] falas;


	//Também vai checar para ver se entrou nas condições fala
    void Start () {
        textoBalao = BalaoFalas.GetComponentInChildren<Text>();
        BalaoFalas.SetActive(false);
	}

    //Essa função que coloca o texto da posição escolhida na tela, chamada de outros scripts
    public void mostrarTexto(int posTexto) {
        if(posTexto >= 0 && posTexto < falas.Length) {
            if (isShowingText) {
                StopCoroutine("displayText");
            }
            StartCoroutine("displayText", posTexto);
        }
    }

    IEnumerator displayText(int posTexto) {

        isShowingText = true;
        //Delay inicial, se possível depois fazer um transição
        yield return new WaitForSeconds(0.4f);
        //Ativa Balao
        BalaoFalas.SetActive(true);

        //Coloca a string no balao letra por letra
        char[] caracteres = falas[posTexto].ToCharArray();
        string dialogo = "";

        for(int x =0; x < caracteres.Length; x++) {
            dialogo = dialogo + caracteres[x];
            textoBalao.text =  dialogo;
            yield return new WaitForSeconds(velocidadeAparecer);
        }
        //Tempo até o balao desaparecer 
        yield return new WaitForSeconds(tempoDeDurar);
        //Balão desaparecer 
        BalaoFalas.SetActive(false);
        isShowingText = false;
    }
	
}