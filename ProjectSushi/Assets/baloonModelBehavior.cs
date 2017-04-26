using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloonModelBehavior : MonoBehaviour {
    baloonBehavior _balonBehavor;
	// Use this for initialization
	void Start () {
        _balonBehavor = transform.parent.GetComponent<baloonBehavior>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            _balonBehavor.breakSelf();
        }
    }
}
