using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public int direction; // 0 = up, 1 = down, 2 = left, 3 = right

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
