using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour {
    public GameObject text;
    private int numBeats = 0;
    public int totalBeats;

    public GameObject arrowSpawner;
    public GameObject paddle;
    public int direction = 1; // 0 = up, 1 = down, 2 = left, 3 = right

    public AudioSource song;
    //public AudioClip reset;
    public GameObject endMenu;
    public Text endScore;
    private bool gameOver = false;

    public Slider healthBar;
    private float curHealth = 20;
    private float totalHealth = 30;

    public Text scoreText;
    public Text streakText;
    private int score = 0;
    private int streak = 1;

    private void Start() {
        Time.timeScale = 1;
        //direction = 1;
        //totalHealth = 30;
        //curHealth = totalHealth;
    }

    private void Update() {
        healthBar.value = curHealth / totalHealth;
        scoreText.text = "SCORE: " + score;
        streakText.text = "STREAK: " + streak + "x";

        if(!gameOver) {
            if(Input.GetKeyDown("z")) {
                Time.timeScale = 0;
                song.Pause();
            } else if(Input.GetKeyDown("x")) {
                Time.timeScale = 1;
                song.UnPause();
            } else if(/*Input.GetKeyDown("escape") ||*/ curHealth == 0) {
                EndRun();
            }
        }

        if(gameOver) {
            if(Input.GetKeyDown("return")) {
                //song.clip = reset;
                /*switch(GameInfo.menuIndex) {
                    case 0:
                        SceneManager.LoadScene("Normal");
                        break;
                    case 1:
                        SceneManager.LoadScene("Hard");
                        break;
                }*/
                SceneManager.LoadScene("Reset");
            } else if(Input.GetKeyDown("escape")) {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Arrow>().direction == direction) {
            Debug.Log("hit");
            paddle.GetComponent<Paddle>().Hit();

            curHealth++;
            if(curHealth > totalHealth) {
                curHealth = totalHealth;
            }
            streak++;
        } else {
            Debug.Log("miss");
            paddle.GetComponent<Paddle>().Miss();

            curHealth -= 5;
            if(curHealth < 0) {
                curHealth = 0;
            }
            streak = 1;
        }
        score += 10 * streak;
        other.GetComponent<Arrow>().ArrowHit();

        numBeats++;
        text.GetComponent<Text>().text = "" + numBeats;

        if(numBeats == totalBeats - 1) {
            arrowSpawner.GetComponent<ArrowSpawner>().StopArrows();
            Invoke("ShowEndMenu", 0.75f);
        }
    }

    private void EndRun() {
        Time.timeScale = 0;
        song.Stop();
        ShowEndMenu();
        //Invoke("ShowEndMenu", 1f);
    }

    private void ShowEndMenu() {
        gameOver = true;
        endMenu.SetActive(true);
        endScore.text = "SCORE: " + score;
    }
}
