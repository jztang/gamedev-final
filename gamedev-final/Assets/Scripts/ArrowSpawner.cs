using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {
	public GameObject arrowPrefab;
    public float arrowSpeed;
    public float bpm;

    private Vector3[] spawnPos = {new Vector3(0.1f, 6f, 1f), new Vector3(0.1f, -6f, 1f), 
                                  new Vector3(-6f, 0f, 1f), new Vector3(6f, 0f, 1f)};
    private Vector3[] spawnRot = {new Vector3(0f, 0f, 180f), new Vector3(0f, 0f, 0f),
                                  new Vector3(0f, 0f, 270f), new Vector3(0f, 0f, 90f)};

    private void Start() {
        InvokeRepeating("StartArrows", 3f, bpm);
    }

    private void bpmToFreq(float bpm) { // beats per minute -> seconds per arrow

    }

    private void StartArrows() {
        GameObject arrow = Instantiate(arrowPrefab);
        int dir = Random.Range(0, 4);
        arrow.transform.position = spawnPos[dir];
        arrow.transform.eulerAngles = spawnRot[dir];
        arrow.GetComponent<Arrow>().ShootArrow(arrowSpeed, dir);
    }
}
