using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    private void Start() {
        GameInfo.menuIndex = 0;
    }

    private void Update() {
        if(Input.GetKeyDown("escape")) {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        } else if(Input.anyKey) {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
