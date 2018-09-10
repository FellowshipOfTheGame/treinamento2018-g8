﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

    GameObject icone;
    Sprite controle, bolinhaazul, bolinhavermelha, aviao;
    PickObjects pickobjects;
    Image imagem_brinquedo;

	void Start () {
        imagem_brinquedo = GameObject.Find("BrinquedoPego").GetComponent<Image>();
        imagem_brinquedo.gameObject.SetActive(false);
        controle = Resources.Load<Sprite>("controle");
        bolinhaazul = Resources.Load<Sprite>("Sprites/bolinhaazul");
        bolinhavermelha = Resources.Load<Sprite>("bolinhavermelha");
        aviao = Resources.Load<Sprite>("aviao");
        pickobjects = GameObject.Find("PickUpArea").GetComponent<PickObjects>();
	}
	
    public void Trocar_icone()
    {
        if(pickobjects.segurandoObj)
        {
            imagem_brinquedo.gameObject.SetActive(true);
            if(pickobjects.objetoAPegar.tag == "BolinhaVermelha")
            {
                imagem_brinquedo.sprite = bolinhavermelha;
            }else if(pickobjects.objetoAPegar.tag == "BolinhaAzul")
            {
                imagem_brinquedo.sprite = bolinhaazul;
            }else
            {
                imagem_brinquedo.gameObject.SetActive(false);
            }
        }else
        {
            imagem_brinquedo.gameObject.SetActive(false);
        }
    }
}