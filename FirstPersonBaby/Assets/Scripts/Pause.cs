using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool paused = false;
    CameraScript camerascript;
    PickObjects pickobjects;
    GameObject pausemenu;

	void Start () {
        camerascript = GameObject.FindWithTag("MainCamera").GetComponent<CameraScript>();
        pickobjects = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        pausemenu = GameObject.Find("Pause Menu");
        pausemenu.SetActive(false);
	}
	
	void Update () {
		if(!paused)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                Time.timeScale = 0;
                paused = true;
                camerascript.enabled = false;
                pickobjects.enabled = false;
                pausemenu.SetActive(true);
            }
        }else
        {
            if(Input.GetButtonDown("Cancel"))
            {
                Time.timeScale = 1;
                paused = false;
                camerascript.enabled = true;
                pickobjects.enabled = true;
                pausemenu.SetActive(false);
            }
        }
	}
}
