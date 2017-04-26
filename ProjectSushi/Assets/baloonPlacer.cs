using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloonPlacer : MonoBehaviour {


    public GameObject baloon;

    [Header("Spawn properties.")]
    [Tooltip("X/Y Min/Max forward distance to be insantiated,")]
    public Vector2 forwardRange = new Vector2(15, 40);
    public float sideRange = 15;
    public float height = 1.5f;

    [Tooltip("X average cooldown, Y noise on cooldown. In seconds.")]
    public Vector2 cooldown = new Vector2(14, 6);


    IEnumerator baloonFactory() {
        while (true) {
            Vector3 instantiatePos = new Vector3(transform.position.x + Random.Range(-sideRange, sideRange), 
                                                 height, 
                                                 transform.position.z + Random.Range(forwardRange.x, forwardRange.y));
            Instantiate(baloon, instantiatePos, Quaternion.identity);
            yield return new WaitForSeconds(cooldown.x + Random.Range(-cooldown.y, cooldown.y));
        }

    }
	// Use this for initialization
	void Start () {
        StartCoroutine(baloonFactory());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
