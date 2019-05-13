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

    public AudioClip menuStart;
    public AudioClip menuSelect;

    public Camera mainCamera;
    public SpriteRenderer heartSpriteRend;

    public Text difficultyText;
    public Text scoreText;
    public GameObject credits;
    public GameObject screenFilter;

    public SpriteRenderer bgSpriteRend;
    public Sprite bgEasy;
    public Sprite bgNormal;
    public Sprite bgHard;
    public Sprite bgUndying;

    public GameObject arrowLeft;
    public GameObject arrowRight;

    private void Start() {
        GetMenu();
        GetComponent<AudioSource>().PlayOneShot(menuStart, 1f);
    }

    private void Update() {
        // Player input
        if(Input.GetKeyDown("up") || Input.GetKeyDown("w")) {
            transform.position = paddleUpPos;
            transform.eulerAngles = paddleUpRot;
        } else if(Input.GetKeyDown("down") || Input.GetKeyDown("s")) {
            transform.position = paddleDownPos;
            transform.eulerAngles = paddleDownRot;
        } else if(Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
            transform.position = paddleLeftPos;
            transform.eulerAngles = paddleLeftRot;

            if(GameInfo.menuIndex > 0) {
                GameInfo.menuIndex--;
                GetComponent<AudioSource>().PlayOneShot(menuSelect, 1f);
                GetMenu();
            }
        } else if(Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
            transform.position = paddleRightPos;
            transform.eulerAngles = paddleRightRot;

            if(GameInfo.menuIndex < 4) {
                GameInfo.menuIndex++;
                GetComponent<AudioSource>().PlayOneShot(menuSelect, 1f);
                GetMenu();
            }
        } else if(Input.GetKeyDown("return")) { // Difficulty selected + start
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
        } else if(Input.GetKeyDown("escape")) { // Back to start screen
            SceneManager.LoadScene("StartScreen");
        }
    }

    // Set the UI of the menu depending on the menuIndex
    private void GetMenu() {
        difficultyText.enabled = true;
        scoreText.enabled = true;
        arrowLeft.SetActive(true);
        arrowRight.SetActive(true);
        credits.SetActive(false);
        screenFilter.SetActive(false);

        switch(GameInfo.menuIndex) {
            case 0: // Easy
                mainCamera.backgroundColor = new Color(0.6719f, 0.7734f, 0.8828f, 1f);
                heartSpriteRend.color = new Color(0.3516f, 0.5703f, 0.7969f, 1f);
                difficultyText.text = "EASY";
                scoreText.text = "BEST: " + PlayerPrefs.GetInt("Easy", 0);
                bgSpriteRend.sprite = bgEasy;
                arrowLeft.SetActive(false);
                break;
            case 1: // Normal
                mainCamera.backgroundColor = new Color(0.8555f, 0.5508f, 0.7578f, 1f);
                heartSpriteRend.color = new Color(0.7422f, 0.4297f, 0.6406f, 1f);
                difficultyText.text = "NORMAL";
                scoreText.text = "BEST: " + PlayerPrefs.GetInt("Normal", 0);
                bgSpriteRend.sprite = bgNormal;
                break;
            case 2: // Hard
                mainCamera.backgroundColor = new Color(0.9102f, 0.6602f, 0.625f, 1f);
                heartSpriteRend.color = new Color(0.8588f, 0.4941f, 0.4431f, 1f);
                difficultyText.text = "HARD";
                scoreText.text = "BEST: " + PlayerPrefs.GetInt("Hard", 0);
                bgSpriteRend.sprite = bgHard;
                break;
            case 3: // Undying
                mainCamera.backgroundColor = new Color(0.8828f, 0.8828f, 0.8828f, 1f);
                heartSpriteRend.color = new Color(0.2549f, 0.2549f, 0.2549f, 1f);
                difficultyText.text = "UNDYING";
                scoreText.text = "BEST: " + PlayerPrefs.GetInt("Undying", 0);
                bgSpriteRend.sprite = bgUndying;
                break;
            case 4: // Credits
                difficultyText.enabled = false;
                scoreText.enabled = false;
                arrowRight.SetActive(false);
                credits.SetActive(true);
                screenFilter.SetActive(true);
                break;
        }
    }
}
