using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMenu : MonoBehaviour {

    public void loadHUB() {
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}
