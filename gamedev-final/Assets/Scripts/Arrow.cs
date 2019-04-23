using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private Vector3 startPos;
	private Vector3 endPos = new Vector3(0f, 0f, -2f);
	private float startTime;
	private float journeyLength;

	public float speed = 1f;

    private void Start() {
        
    }

    private void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
    }

    public void spawnUp() {
    	transform.position = new Vector3(0f, 6f, -2f);
        transform.eulerAngles = new Vector3(0f, 0f, 270f);
    }

    public void shootArrow() {

    }
}
