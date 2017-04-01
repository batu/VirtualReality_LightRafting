using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBehavior : MonoBehaviour {


    public int maximumHealth = 3;
    int currentHealth;

    public GameObject model;
    Material modelMaterial;

    Color[] colors = { Color.green, Color.yellow, Color.red };

    void OnCollisionEnter(Collision col) {

        if (col.collider.tag == "Obstacle" ) {
            currentHealth -= 1;
            col.collider.tag = "Collided_Obstacle";
        }
        if(!(currentHealth < 1)) modelMaterial.color = colors[3 - currentHealth];

        if(currentHealth == 0) {
            Destroy(model);
        }
    }
	// Use this for initialization
	void Start () {
        currentHealth = maximumHealth;
        modelMaterial = model.GetComponent<Renderer>().material;
        modelMaterial.color = colors[3 - maximumHealth];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
