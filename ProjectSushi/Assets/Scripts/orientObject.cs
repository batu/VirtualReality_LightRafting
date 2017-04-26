using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientObject : MonoBehaviour {

	public Transform boatTR;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = boatTR.position + offset;
	}
}
