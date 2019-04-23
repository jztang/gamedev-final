using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {
	public GameObject arrowPrefab;

	private Vector3 upSpawnPos = new Vector3(0f, 6f, -2f);
	private Vector3 upSpawnRot = new Vector3(0f, 0f, 270f);
	private Vector3 downSpawnPos = new Vector3(0f, -6f, -2f);
	private Vector3 downSpawnRot = new Vector3(0f, 0f, 90f);
	private Vector3 leftSpawnPos = new Vector3(-6f, 0f, -2f);
	private Vector3 leftSpawnRot = new Vector3(0f, 0f, 0f);
	private Vector3 rightSpawnPos = new Vector3(6f, 0f, -2f);
	private Vector3 rightSpawnRot = new Vector3(0f, 0f, 180f);

    private void Start() {
        GameObject up = Instantiate(arrowPrefab);
        up.transform.position = upSpawnPos;
        up.transform.eulerAngles = upSpawnRot;

        GameObject down = Instantiate(arrowPrefab);
        down.transform.position = downSpawnPos;
        down.transform.eulerAngles = downSpawnRot;

        GameObject left = Instantiate(arrowPrefab);
        left.transform.position = leftSpawnPos;
        left.transform.eulerAngles = leftSpawnRot;

        GameObject right = Instantiate(arrowPrefab);
        right.transform.position = rightSpawnPos;
        right.transform.eulerAngles = rightSpawnRot;
    }

    private void Update() {
        
    }


}
