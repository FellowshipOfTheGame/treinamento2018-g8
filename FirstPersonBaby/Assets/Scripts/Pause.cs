using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    bool paused = false;
    CameraScript camerascript;
    PickObjects pickobjects;
    GameObject pausemenu;

	void Start () {

        Button quit_button = GameObject.Find("Quit Button").GetComponent<Button>();
        camerascript = GameObject.FindWithTag("MainCamera").GetComponent<CameraScript>();
        pickobjects = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        pausemenu = GameObject.Find("Pause Menu");
        quit_button.onClick.AddListener(QuitGame);
        pausemenu.SetActive(false);
	}
	
	void Update () {
		if(!paused)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                Time.timeScale = 0;
                paused = true;
           
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                camerascript.cursorIsLocked = true;
                pickobjects.enabled = true;
                pausemenu.SetActive(false);
                
            }
        }
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
