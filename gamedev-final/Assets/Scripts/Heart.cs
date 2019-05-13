using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour {
    public GameObject text;
    private int numBeats = 0; // Number of beats played in the current song
    public int totalBeats; // Total number of beats in the song

    public GameObject arrowSpawner;
    public GameObject paddle;
    public int direction = 1; // 0 = up, 1 = down, 2 = left, 3 = right

    public string difficulty;
    public AudioSource song;
    public AudioClip startSound;
    public AudioClip hitSound;
    public AudioClip missSound;
    public GameObject endMenu;
    public Text yourScore;
    public Text highScore;  
    public Text newHighScore;
    private bool gameOver = false;
    private bool endPause = false;

    public Slider healthBar;
    public Slider streakBar;
    private float curHealth = 20;
    private float totalHealth = 30;

    public Text scoreText;
    public Text streakText;
    private int score = 0;
    private int streak = 1;
    private int subStreak = 0;

    private void Start() {
        Time.timeScale = 1;
        GetComponent<AudioSource>().PlayOneShot(startSound, 1f);
    }

    private void Update() {
        healthBar.value = curHealth / totalHealth;
        streakBar.value = subStreak / 10f;
        scoreText.text = score + "";
        streakText.text = streak + "x";

        if(!gameOver && !endPause) {
            if(Input.GetKeyDown("z")) { // Pause the game (dev tool)
                Time.timeScale = 0;
                song.Pause();
            } else if(Input.GetKeyDown("x")) { // Resume the game (dev tool)
                Time.timeScale = 1;
                song.UnPause();
            } else if(Input.GetKeyDown("escape")) { // Stop the level
                EndRun();
                GetComponent<AudioSource>().PlayOneShot(missSound, 1f);
            }
        }

        if(gameOver && !endPause) {
            if(Input.GetKeyDown("return")) { // Restart the level
                SceneManager.LoadScene("Reset");
            } else if(Input.GetKeyDown("escape")) { // Go to the main menu
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Arrow>().direction == direction) { // Arrow successfully blocked
            Debug.Log("hit");
            GetComponent<AudioSource>().PlayOneShot(hitSound, 1f);

            curHealth++;
            subStreak++;
            if(curHealth > totalHealth) {
                curHealth = totalHealth;
            }
            if(subStreak == 10 && streak < 4) {
                streak++;
            }
            if(subStreak == 11 && streak < 4) {
                subStreak = 1;
            }
        	score += 25 * streak;
        } else { // Arrow unsuccessfully blocked
            Debug.Log("miss");
            GetComponent<AudioSource>().PlayOneShot(missSound, 1f);

            curHealth -= 5;
            if(curHealth < 0) {
                curHealth = 0;
            }

            if(curHealth > 0) {
                paddle.GetComponent<Paddle>().Miss();
            }
            streak = 1;
            subStreak = 0;
        }

        if(curHealth == 0 && PlayerPrefs.GetInt("Invincible", 0) == 0) { // Check if player is dead (out of health)
            EndRun();
        } else {
            other.GetComponent<Arrow>().ArrowHit();
            GetComponent<Animator>().Play("heartbeat", 0, 0);
        }

        numBeats++;
        text.GetComponent<Text>().text = "" + numBeats;

        if(numBeats == totalBeats - 1) { // End the level when the song is over
            arrowSpawner.GetComponent<ArrowSpawner>().StopArrows();
            Invoke("ShowEndMenu", 2f);
        }
    }

    // End the level
    private void EndRun() {
        song.Stop();
        arrowSpawner.GetComponent<ArrowSpawner>().StopArrows();
        foreach(GameObject arrowObj in GameObject.FindGameObjectsWithTag("Arrow")) {
            arrowObj.GetComponent<Arrow>().ArrowStop();
        }
        endPause = true;
        Invoke("ShowEndMenu", 1f);
    }

    // Show the end menu w/ high scores
    private void ShowEndMenu() {
        gameOver = true;
        endPause = false;
        yourScore.text = score + "";
        if(score > PlayerPrefs.GetInt(difficulty, 0)) { // New high score
            PlayerPrefs.SetInt(difficulty, score);
            newHighScore.enabled = true;
        }
        highScore.text = PlayerPrefs.GetInt(difficulty, 0) + "";
        endMenu.SetActive(true);
    }
}
