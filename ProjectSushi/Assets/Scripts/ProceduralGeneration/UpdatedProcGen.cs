using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedProcGen : MonoBehaviour {

	boatScript boatScript;
	float lastchecked;

    GameObject obstacleHolder;
    public GameObject obstacle;
	float forwardSpeed = 20f;
	float sideSpeed = 20f;
	public float spawnLeftRightRange;
	public float visualConeRadius = 200f;
    public float spawnMaxStep = 10f;
	public float spawnMinStep = 2f;
	public float spawnThreshold = 30f;
	Transform boat;

	// Use this for initialization
	void Start () {
		boatScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<boatScript> ();
		//forwardSpeed = boatScript.forwardSpeed;
		//sideSpeed = boatScript.sideSpeed;
        obstacleHolder = GameObject.FindGameObjectWithTag("Obstacle_Holder");
		spawnLeftRightRange = ((visualConeRadius / forwardSpeed) * sideSpeed) + visualConeRadius / 4;
		spawnInitialObstacles();
		boat = GameObject.FindGameObjectWithTag ("Player").transform;
		lastchecked = boat.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (boat.position.z - lastchecked >= spawnThreshold) {
			GenerateMoreObstacles ();
			lastchecked =+ boat.position.z;
	}
}

    void spawnInitialObstacles() {
			for (float spawn_z = 0; spawn_z < visualConeRadius;) {
            GameObject toInstantiate = obstacle;
            toInstantiate.transform.localScale = new Vector3(Random.Range(1,5), Random.Range(1, 5), Random.Range(1, 5));

            spawn_z += Random.Range(spawnMinStep, spawnMaxStep);
            Vector3 instantiatePosition = new Vector3(  Random.Range( -spawnLeftRightRange, spawnLeftRightRange), 
                                                        transform.position.y, 
                                                        transform.position.z + spawn_z);

            Instantiate(toInstantiate, instantiatePosition, Random.rotationUniform);
        }
    }
	
	void GenerateMoreObstacles() {
		for (float spawn_z = 0; spawn_z <= spawnThreshold;) {
		//float spawn_z = 0;
		GameObject toInstantiate = obstacle;
		toInstantiate.transform.localScale = new Vector3(Random.Range(1,5), Random.Range(1, 5), Random.Range(1, 5));
		spawn_z += Random.Range(spawnMinStep, spawnMaxStep);
		Vector3 instantiatePosition = new Vector3(  Random.Range( -spawnLeftRightRange + boat.position.x, spawnLeftRightRange + boat.position.x), 
			transform.position.y,
			transform.position.z + spawn_z + visualConeRadius - spawnThreshold);

		Instantiate(toInstantiate, instantiatePosition, Random.rotationUniform);
		}
	}
}