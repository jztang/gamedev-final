using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
    // Attached to a blank scene, which immediately loads one of the game scenes based on the menuIndex
    // Used when restarting a level in order to properly reload the song and keep the timing consistent
    private void Start() {
        switch(GameInfo.menuIndex) {
            case 0:
                SceneManager.LoadScene("Easy");
                break;
            case 1:
                SceneManager.LoadScene("Normal");
                break;
            case 2:
                SceneManager.LoadScene("Hard");
                break;
            case 3:
                SceneManager.LoadScene("Undying");
                break;
        }
    }
}
