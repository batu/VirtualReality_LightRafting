using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardMove : MonoBehaviour {

	public GameObject oar;
	Vector3 lastOarPosition;
	Vector3 nowOarPosition;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		lastOarPosition = oar.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		nowOarPosition = oar.transform.position;
		if (nowOarPosition.y < 0) {
			rb.AddForce (lastOarPosition.x - nowOarPosition.x, 0, lastOarPosition.z - nowOarPosition.z, ForceMode.Impulse);
		}
		lastOarPosition = nowOarPosition;
	}
}
