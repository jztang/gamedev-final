using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private Vector3 paddleUpPos = new Vector3(0.035f, 0.595f, 0f);
    private Vector3 paddleUpRot = new Vector3 (0f, 0f, 0f);
    private Vector3 paddleDownPos = new Vector3(0.027f, -0.595f, 0f);
    private Vector3 paddleDownRot = new Vector3(0f, 0f, 180f);
    private Vector3 paddleLeftPos = new Vector3(-0.557f, 0.006f, 0f);
    private Vector3 paddleLeftRot = new Vector3(0f, 0f, 90f);
    private Vector3 paddleRightPos = new Vector3(0.616f, -0.005f, 0f);
    private Vector3 paddleRightRot = new Vector3(0f, 0f, 270f);

    public Text difficultyText;

    private void Start() {
        GetMenu();
    }

    private void Update() {
        if(Input.GetKeyDown("up") || Input.GetKeyDown("w")) {
            transform.position = paddleUpPos;
            transform.eulerAngles = paddleUpRot;
        } else if(Input.GetKeyDown("down") || Input.GetKeyDown("s")) {
            transform.position = paddleDownPos;
            transform.eulerAngles = paddleDownRot;
        } else if(Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
            transform.position = paddleLeftPos;
            transform.eulerAngles = paddleLeftRot;
            if(GameInfo.menuIndex > 0) GameInfo.menuIndex--;
            GetMenu();
        } else if(Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
            transform.position = paddleRightPos;
            transform.eulerAngles = paddleRightRot;
            if(GameInfo.menuIndex < 1) GameInfo.menuIndex++;
            GetMenu();
        } else if(Input.GetKeyDown("return")) {
            switch(GameInfo.menuIndex) {
                case 0:
                    SceneManager.LoadScene("Normal");
                    break;
                case 1:
                    SceneManager.LoadScene("Hard");
                    break;
            }
        } else if(Input.GetKeyDown("escape")) {
            SceneManager.LoadScene("StartScreen");
        }
    }

    private void GetMenu() {
        switch(GameInfo.menuIndex) {
            case 0:
                difficultyText.text = "NORMAL";
                break;
            case 1:
                difficultyText.text = "HARD";
                break;
        }
    }
}
