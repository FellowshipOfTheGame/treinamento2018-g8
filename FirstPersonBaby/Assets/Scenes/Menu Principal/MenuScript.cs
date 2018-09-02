﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    GameObject o_button;
    public float final_size;
    public float time;
    float time_spent = 0;
    float per_frame;
    bool getting_bigger = false;

	void Start () {
        o_button = GameObject.Find("Play Button");
        Button start_button = GameObject.Find("Play Button").GetComponent<Button>();
        start_button.onClick.AddListener(startgame);
        per_frame = (1.0f - final_size) / time;
	}

    void Update()
    {
        if(!getting_bigger)
        {
            o_button.transform.localScale -= o_button.transform.localScale * per_frame * Time.deltaTime;
        }else
        {
            o_button.transform.localScale += o_button.transform.localScale * per_frame * Time.deltaTime;
        }
        time_spent += Time.deltaTime;
        if(time_spent >= time)
        {
            time_spent = 0;
            if(!getting_bigger)
            {
                getting_bigger = true;
            }else
            {
                getting_bigger = false;
            }
        }
    }

    void startgame()
    {
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}