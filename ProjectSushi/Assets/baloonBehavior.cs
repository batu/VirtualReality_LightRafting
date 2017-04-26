using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloonBehavior : MonoBehaviour {

    scoreKeeper _scoreKeeper;
    GameObject baloonModel, shardContainer;
    Collider baloonCollider;
    AudioSource breakSound;
    

	// Use this for initialization
	void Start () {
        baloonModel = transform.GetChild(0).gameObject;
        shardContainer = transform.GetChild(1).gameObject;
        BUtils.Toolbox.debugPrint(baloonModel);
        breakSound = GetComponent<AudioSource>();
        baloonCollider = baloonModel.GetComponent<Collider>();
        _scoreKeeper = GameObject.FindWithTag("GameManager").GetComponent<scoreKeeper>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void breakSelf() {
        breakSound.pitch = Random.Range(.8f, 1.2f);
        breakSound.PlayOneShot(breakSound.clip);

        baloonModel.SetActive(false);
        shardContainer.SetActive(true);

        _scoreKeeper.addBaloonToScore();

        Destroy(baloonModel, 3f);
        Destroy(shardContainer, 3f);
        Destroy(gameObject, 4f);
    }

}
