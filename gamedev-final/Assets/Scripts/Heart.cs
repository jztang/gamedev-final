using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {
    public GameObject text;
    private int numBeats = 0;
    public int totalBeats;

    public GameObject arrowSpawner;
    public GameObject paddle;
    public int direction; // 0 = up, 1 = down, 2 = left, 3 = right

    private void Start() {
        direction = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Arrow>().direction == direction) {
            Debug.Log("hit");
            paddle.GetComponent<Paddle>().Hit();
        } else {
            Debug.Log("miss");
            paddle.GetComponent<Paddle>().Miss();
        }
        other.GetComponent<Arrow>().ArrowHit();

        numBeats++;
        text.GetComponent<Text>().text = "" + numBeats;

        if(numBeats == totalBeats - 1) {
            arrowSpawner.GetComponent<ArrowSpawner>().StopArrows();
        }
    }
}
