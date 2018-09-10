using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMenu : MonoBehaviour {

    public void loadHUB() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1  , LoadSceneMode.Single);
    }
}
