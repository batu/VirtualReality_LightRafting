using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class damageBehavior : MonoBehaviour {

	public float lerpSpeed = 1f;
	public float goDownSpeed = 5f;
	public float yDownOffset = 5f;

	public GameObject blackScreen;
    public int maximumHealth = 1;
    int currentHealth;

    public GameObject model;


    Collider boatCollider;
    Material modelMaterial;
	Material bsMat;

	IEnumerator fadeToBlack(){
		float i = 0.0f;
		float rate = 1.0f / lerpSpeed;
		while (i < 1.0) {
			i += Time.deltaTime * rate;
			bsMat.color = new Color(bsMat.color.r, bsMat.color.g, bsMat.color.b, Mathf.Lerp(0, 1, i));
			yield return null; 
		}
	}

	IEnumerator GoDown(){
		float i = 0.0f;
		float rate = 1.0f / goDownSpeed;
		while (i < 1.0) {
			i += Time.deltaTime * rate;
			transform.position = Vector3.Slerp(transform.position, new Vector3( transform.position.x, -yDownOffset, transform.position.z), i);
			yield return null; 
		}
		yield return new WaitForSecondsRealtime (5);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

    Color[] colors = { Color.green, Color.yellow, Color.red };

    void OnCollisionEnter(Collision col) {

        if (col.collider.tag == "Obstacle" ) {
            currentHealth -= 1;
            col.collider.tag = "Collided_Obstacle";
        }
			
        if(currentHealth == 0) {
            //model.GetComponent<MeshCollider>().enabled = false;
            boatCollider.enabled = false;
            StartCoroutine (fadeToBlack ());
			StartCoroutine (GoDown ());
            Destroy(model);
        }
    }
	// Use this for initialization
	void Start () {
        boatCollider = transform.GetChild(3).transform.GetComponentInChildren<Collider>();
        currentHealth = maximumHealth;
		bsMat = blackScreen.GetComponent<Renderer> ().material;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
