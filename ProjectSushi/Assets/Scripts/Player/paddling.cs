using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddling : MonoBehaviour {

    //This script should be attached to each controller (Controller Left or Controller Right)

    boatScript _boatScript;
    public float samplingTime = 0.3f;
    public float paddling_distance = 1f;
	public float sideMagnitude = 1f;

    Vector3 firstSample = Vector3.zero;
    Vector3 secondSample = Vector3.zero;
	Rigidbody prb;

	GameObject player;

    // Getting a reference to the controller GameObject
    private SteamVR_TrackedObject trackedObj;
    // Getting a reference to the controller Interface
    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake() {
        // initialize the trackedObj to the component of the controller to which the script is attached
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
		
    
    void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		prb = player.GetComponent<Rigidbody> ();
    }

	public void paddle(){
		print ("paddle function is called");
		if (transform.position.x < 9) {
			prb.AddForce (Vector3.right * sideMagnitude, ForceMode.Impulse);
		} else {
			prb.AddForce (-Vector3.right * sideMagnitude, ForceMode.Impulse);
		}
	}

    // Update is called once per frame
    void Update() {


        // Getting the Touchpad Axis
        if (Controller.GetAxis() != Vector2.zero) {
            //Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // Getting the Trigger press
        if (Controller.GetHairTriggerDown()) {
            //Debug.Log(gameObject.name + " Trigger Press");
        }

        // Getting the Trigger Release
        if (Controller.GetHairTriggerUp()) {
            //Debug.Log(gameObject.name + " Trigger Release");
        }

        // Getting the Grip Press
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            //Debug.Log(gameObject.name + " Grip Press");
        }

        // Getting the Grip Release
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
            //Debug.Log(gameObject.name + " Grip Release");
        }
    }
}