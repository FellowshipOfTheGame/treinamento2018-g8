using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    bool paused = false;
    public KeyCode key;
    CameraScript camerascript;
    CameraScript camerascript_clone;
    PickObjects pickobjects;
    GameObject pausemenu;

	void Start () {

        Button quit_button = GameObject.Find("Quit Button").GetComponent<Button>();
        
        camerascript = GameObject.Find("Player").transform.Find("Main Camera").GetComponent<CameraScript>();
       /* if(GameObject.Find("BrinquedoRobo") != null)
        {
            camerascript_clone = GameObject.Find("BrinquedoRobo").transform.Find("CameraRobo").GetComponent<CameraScript>();
        }
        else
        {
            camerascript_clone = null;
        }*/
        pickobjects = GameObject.FindWithTag("AreaPickUp").GetComponent<PickObjects>();
        pausemenu = GameObject.Find("Pause Menu");
        quit_button.onClick.AddListener(QuitGame);
        
        pausemenu.SetActive(false);
	}
	
	void Update () {
		if(!paused)
        {
            if(Input.GetKeyDown(key) == true)
            {
                Time.timeScale = 0;
                paused = true;
           
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                camerascript.enabled = false;
               /* if(camerascript_clone != null)
                {
                   camerascript_clone.enabled = false;
                }*/
                pickobjects.enabled = false;
                pausemenu.SetActive(true);
                
            }
        }else
        {
            if(Input.GetKeyDown(key) == true)
            {
                Time.timeScale = 1;
                paused = false;
                camerascript.enabled = true;
              /* if (camerascript_clone != null)
               {
                   camerascript_clone.enabled = true;
               }*/
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
