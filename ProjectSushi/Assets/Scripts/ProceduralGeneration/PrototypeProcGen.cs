using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeProcGen : MonoBehaviour {

    public float spawnTreshold;

    GameObject obstacleHolder;
    public GameObject obstacle;
    public float initialSpawnDistance = 100f;

    public float spawnLeftRightRange = 10f;
    public float spawnMaxStep = 5f;
    public float spawnMinStep = 1f;

	// Use this for initialization
	void Start () {
        obstacleHolder = GameObject.FindGameObjectWithTag("Obstacle_Holder");
        spawnInitialObstacles();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void spawnInitialObstacles() {
        for (float spawn_z = 0; spawn_z < initialSpawnDistance;) {
            GameObject toInstantiate = obstacle;
            toInstantiate.transform.localScale = new Vector3(Random.Range(1,5), Random.Range(1, 5), Random.Range(1, 5));

            spawn_z += Random.Range(spawnMinStep, spawnMaxStep);

            Vector3 instantiatePosition = new Vector3(  Random.Range( -spawnLeftRightRange, spawnLeftRightRange), 
                                                        transform.position.y, 
                                                        transform.position.z + spawn_z);

            Instantiate(toInstantiate, instantiatePosition, Random.rotationUniform);
        }
    }
}
