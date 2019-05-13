using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimFinish : MonoBehaviour {
    // Called at the end of the arrow_hit animation to destroy the arrow gameobject
    public void AnimEnd() {
        Destroy(this.transform.parent.gameObject);
    }
}
