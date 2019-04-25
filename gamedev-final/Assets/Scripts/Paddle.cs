using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private Vector3 paddleUpPos = new Vector3(0f, 1.22f, -1f);
	private Vector3 paddleUpRot = new Vector3 (0f, 0f, 0f);
	private Vector3 paddleDownPos = new Vector3(0f, -1.22f, -1f);
	private Vector3 paddleDownRot = new Vector3(0f, 0f, 180f);
	private Vector3 paddleLeftPos = new Vector3(-1.22f, 0f, -1f);
	private Vector3 paddleLeftRot = new Vector3(0f, 0f, 90f);
	private Vector3 paddleRightPos = new Vector3(1.22f, 0f, -1f);
	private Vector3 paddleRightRot = new Vector3(0f, 0f, 270f);

    public GameObject heart;

    private void Update() {
        if(Input.GetKeyDown("up")) {
        	transform.position = paddleUpPos;
        	transform.eulerAngles = paddleUpRot;
            heart.GetComponent<Heart>().direction = 0;
        } else if(Input.GetKeyDown("down")) {
        	transform.position = paddleDownPos;
        	transform.eulerAngles = paddleDownRot;
            heart.GetComponent<Heart>().direction = 1;
        } else if(Input.GetKeyDown("left")) {
        	transform.position = paddleLeftPos;
        	transform.eulerAngles = paddleLeftRot;
            heart.GetComponent<Heart>().direction = 2;
        } else if(Input.GetKeyDown("right")) {
        	transform.position = paddleRightPos;
        	transform.eulerAngles = paddleRightRot;
            heart.GetComponent<Heart>().direction = 3;
        }
    }
}
