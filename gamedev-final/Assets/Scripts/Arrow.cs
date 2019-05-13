using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private Vector3 startPos;
	private Vector3 endPos = new Vector3(0f, 0f, 0f);
	private float startTime;
	private float journeyLength;
    private bool shoot = false;
	private float speed;
    public int direction; // 0 = up, 1 = down, 2 = left, 3 = right

    public GameObject arrowAnim;

    private void Update() {
        // Lerp to the center of the heart
        if(shoot) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
        }
    }

    // Start shooting the arrow
    public void ShootArrow(float speed, int direction) {
        this.speed = speed;
        this.direction = direction;
        startPos = transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
        shoot = true;
    }

    // Arrow has hit the heart
    public void ArrowHit() {
        shoot = false;
        GetComponent<SpriteRenderer>().enabled = false;
        arrowAnim.GetComponent<SpriteRenderer>().enabled = true;
        arrowAnim.GetComponent<Animator>().Play("arrow_hit", 0, 0);
    }

    public void ArrowStop() {
        shoot = false;
    }
}
