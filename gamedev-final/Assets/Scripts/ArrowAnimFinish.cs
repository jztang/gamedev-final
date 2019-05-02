using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimFinish : MonoBehaviour {
    public void AnimEnd() {
        Destroy(this.transform.parent.gameObject);
    }
}
