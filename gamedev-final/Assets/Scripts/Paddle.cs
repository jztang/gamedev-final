using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private Vector3 paddleUpPos = new Vector3(0f, 1.37f, -1f);
	private Vector3 paddleUpRot = new Vector3 (0f, 0f, 0f);
	private Vector3 paddleDownPos = new Vector3(0f, -1.37f, -1f);
	private Vector3 paddleDownRot = new Vector3(0f, 0f, 180f);
	private Vector3 paddleLeftPos = new Vector3(-1.37f, 0f, -1f);
	private Vector3 paddleLeftRot = new Vector3(0f, 0f, 90f);
	private Vector3 paddleRightPos = new Vector3(1.37f, 0f, -1f);
	private Vector3 paddleRightRot = new Vector3(0f, 0f, 270f);

    private void Start() {
    	
    }

    private void Update() {
        if(Input.GetKeyDown("up")) {
        	transform.position = paddleUpPos;
        	transform.eulerAngles = paddleUpRot;
        } else if(Input.GetKeyDown("down")) {
        	transform.position = paddleDownPos;
        	transform.eulerAngles = paddleDownRot;
        } else if(Input.GetKeyDown("left")) {
        	transform.position = paddleLeftPos;
        	transform.eulerAngles = paddleLeftRot;
        } else if(Input.GetKeyDown("right")) {
        	transform.position = paddleRightPos;
        	transform.eulerAngles = paddleRightRot;
        }
    }
}
