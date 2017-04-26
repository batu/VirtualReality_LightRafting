using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagement : MonoBehaviour {

	public GameObject ps;
	Vector3 oarPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oarPosition = this.transform.position;
		if (oarPosition.y < 0f && oarPosition.y > -0.01f) {
			GameObject p = Instantiate (ps, oarPosition, Quaternion.identity);
			ParticleSystem yo = p.GetComponent<ParticleSystem>();
			yo.Play ();
			Destroy (p, 1f);
		}
	}
}
