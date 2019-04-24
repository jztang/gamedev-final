using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public int direction; // 1 = up, 2 = down, 3 = left, 4 = right

    private void Start() {
        direction = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Arrow>().direction == direction) {
            Debug.Log("hit");
        } else {
            Debug.Log("miss");
        }

        Destroy(other.gameObject);
    }
}
