using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    private void Start() {
        GameInfo.menuIndex = 0;
        Cursor.visible = false;
        PlayerPrefs.SetInt("Invincible", 0);
    }

    private void Update() {
        if(Input.GetKeyDown("escape")) { // exit the game
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        } else if(Input.GetKeyDown("r")) { // reset all high scores
            PlayerPrefs.SetInt("Easy", 0);
            PlayerPrefs.SetInt("Normal", 0);
            PlayerPrefs.SetInt("Hard", 0);
            PlayerPrefs.SetInt("Undying", 0);
        } else if(Input.GetKeyDown("i")) { // turn on invincibility
            PlayerPrefs.SetInt("Invincible", 1);
        } else if(Input.anyKey) { // start the game
            SceneManager.LoadScene("MainMenu");
        }
    }
}
