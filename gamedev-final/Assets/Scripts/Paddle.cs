using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private Vector3 paddleUpPos = new Vector3(0.035f, 0.595f, 0f);
	private Vector3 paddleUpRot = new Vector3 (0f, 0f, 0f);
	private Vector3 paddleDownPos = new Vector3(0.027f, -0.595f, 0f);
	private Vector3 paddleDownRot = new Vector3(0f, 0f, 180f);
	private Vector3 paddleLeftPos = new Vector3(-0.557f, 0.006f, 0f);
	private Vector3 paddleLeftRot = new Vector3(0f, 0f, 90f);
	private Vector3 paddleRightPos = new Vector3(0.616f, -0.005f, 0f);
	private Vector3 paddleRightRot = new Vector3(0f, 0f, 270f);

    public GameObject heart;

    private void Update() {
        if(Input.GetKeyDown("up") || Input.GetKeyDown("w")) {
        	transform.position = paddleUpPos;
        	transform.eulerAngles = paddleUpRot;
            heart.GetComponent<Heart>().direction = 0;
        } else if(Input.GetKeyDown("down") || Input.GetKeyDown("s")) {
        	transform.position = paddleDownPos;
        	transform.eulerAngles = paddleDownRot;
            heart.GetComponent<Heart>().direction = 1;
        } else if(Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
        	transform.position = paddleLeftPos;
        	transform.eulerAngles = paddleLeftRot;
            heart.GetComponent<Heart>().direction = 2;
        } else if(Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
        	transform.position = paddleRightPos;
        	transform.eulerAngles = paddleRightRot;
            heart.GetComponent<Heart>().direction = 3;
        }
    }

    public void Hit() {
        GetComponent<SpriteRenderer>().color = Color.green;
        Invoke("Reset", 0.15f);
    }

    public void Miss() {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("Reset", 0.15f);
    }

    private void Reset() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
