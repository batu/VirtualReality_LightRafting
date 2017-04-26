using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManagement : MonoBehaviour {

	Vector3 boatPosition;
	Vector2 boatGrid; //where the boat is in grids ( 27*27 )
	Vector2 previousBoatGrid;
	public GameObject hugeWaterPlane;

	// Use this for initialization
	void Start () {
		previousBoatGrid.x = 0f;
		previousBoatGrid.y = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		boatPosition = this.transform.position;
		boatGrid.x = Mathf.Floor((boatPosition.x + 13.5f) / 27f);
		boatGrid.y = Mathf.Floor((boatPosition.z + 13.5f) / 27f);

		if (boatGrid.x != previousBoatGrid.x || boatGrid.y != previousBoatGrid.y) {
			hugeWaterPlane.transform.position = new Vector3 (27f * boatGrid.x, -0.3f, 27f*boatGrid.y);
		}

	}
}
