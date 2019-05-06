using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
    private void Start() {
        switch(GameInfo.menuIndex) {
            case 0:
                SceneManager.LoadScene("Normal");
                break;
            case 1:
                SceneManager.LoadScene("Hard");
                break;
        }
    }
}
