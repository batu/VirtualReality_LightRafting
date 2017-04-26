using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BUtils;

public class boatScript : MonoBehaviour {

    public bool freeRoam = false;
    public GameObject oar;

    public float autoForwardSpeed = 0.05f;
    public float autoForwardMaxSpeed = 10f;

    [Tooltip("X/Z used for side/forward paddle strength. Y used for torque.")]
    public Vector3 paddleMultiplier = new Vector3(4f, 0.35f, 4f);

    [Tooltip("Power that rotates the boat to center.")]
    public float normalizeMagnitude = 15f;

    [Tooltip("Treshold that minimum oar movement will be detected.")]
    public float oarMovementTreshold = 0.05f;

    public float maxSpeedSmoothening = 0.99f;


    [Tooltip("Treshold distance X/Y min/max. If inside min, power is max, if outside max power is 0.")]
    public Vector2 distanceMultiplierMinMax = new Vector2(1,3);

	Vector3 lastOarPosition;
	Vector3 nowOarPosition;

	Vector3 lastOarRelativePosition;
	Vector3 nowOarRelativePosition;

	Rigidbody rb;

	// take the distance. add a power off treshold after 1 and then scale the force between 1-2 to 0
	GameObject eyes;


	// Stores the active boat rotation from 0. Turned left -, turned right +
	float boatRotationOnY;


	void Start() {
		rb = GetComponent<Rigidbody>();
		lastOarPosition = oar.transform.position;
		lastOarRelativePosition = transform.position - oar.transform.position;
		eyes = GameObject.Find ("[CameraRig / Player]");

	}

	void addForwardForce(){
		rb.AddForce (Vector3.forward * autoForwardSpeed, ForceMode.VelocityChange);
	}

	void constrainToSide(){
		transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y,  0);
		if (boatRotationOnY < -90) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 270.5f,  transform.localEulerAngles.z);
		}else if (boatRotationOnY > 90) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 89.5f,  transform.localEulerAngles.z);
		}
	}

	void constrainMaxSpeed(){
		if (rb.velocity.z > autoForwardMaxSpeed) {
			rb.velocity = rb.velocity * maxSpeedSmoothening; //always less than 1;
		}
	}

	void correctToMiddle(){
		float torqueConstant;
		if (boatRotationOnY < -1 && boatRotationOnY > -91) {
			torqueConstant = Mathf.InverseLerp (0, -95f, boatRotationOnY) * normalizeMagnitude;
			rb.AddRelativeTorque (new Vector3 (0f, 
				torqueConstant,
				0f));
		} else if (boatRotationOnY > 1 && boatRotationOnY < 91) {
			torqueConstant = Mathf.InverseLerp (0, 95f, boatRotationOnY) * normalizeMagnitude;
			rb.AddRelativeTorque (new Vector3 (0f, 
				-torqueConstant,
				0f));
		}
	}

	void Update () {

        // Do the required corrections and constraints
        if (!freeRoam) {
            constrainToSide();
            correctToMiddle();
        }

		constrainMaxSpeed ();

		// Add the forward force.
		addForwardForce ();

		// Calculate the rotation
		boatRotationOnY = Vector3.Angle(Vector3.forward, transform.forward);
		boatRotationOnY = transform.rotation.eulerAngles.y > 180 ? - boatRotationOnY : boatRotationOnY;

		//Figure out if the oar is moving
		Vector3 deltaOarPosition = lastOarPosition - nowOarPosition;

		bool movingForward = freeRoam ? true : deltaOarPosition.z > 0;

		// if the oar is moving more than a treshold.
		float oarMovement = (lastOarRelativePosition - nowOarRelativePosition).sqrMagnitude;
		bool oarIsActive = oarMovement > oarMovementTreshold;
		bool paddleUnderWater = nowOarPosition.y < 0;

		if (paddleUnderWater && oarIsActive && movingForward) {
			Vector3 PosToOar = (new Vector3 (transform.position.x, 0, transform.position.z) - new Vector3 (oar.transform.position.x, 0, oar.transform.position.z));

            float distance = Vector3.Distance(oar.transform.position, transform.position);

            float distanceMultiplier = distance < distanceMultiplierMinMax.x ? 1 : Mathf.InverseLerp(distanceMultiplierMinMax.y,
                                                                                                     distanceMultiplierMinMax.x, 
                                                                                                     distance);

            float torque = deltaOarPosition.x > 0 ? (transform.position.x - oar.transform.position.x) : -(transform.position.x - oar.transform.position.x);
			float sideMultiplier = (transform.position.x - oar.transform.position.x) > 0 ? 1 : -1;
			float dotTorque = Mathf.Clamp01(Vector3.Dot(new Vector3(deltaOarPosition.x, 0, deltaOarPosition.z).normalized , transform.forward.normalized));
			float TorqueDistanceMultiplier = PosToOar.magnitude;
          
            rb.AddRelativeTorque(new Vector3(0,dotTorque * torque * sideMultiplier * paddleMultiplier.y * TorqueDistanceMultiplier, 0f), ForceMode.Impulse);
            rb.AddRelativeForce(new Vector3(deltaOarPosition.x * paddleMultiplier.x, 0, deltaOarPosition.z * paddleMultiplier.z), ForceMode.Impulse);

            //rb.AddRelativeTorque(new Vector3(0, distanceMultiplier* dotTorque * torque * sideMultiplier * paddleMultiplier.y * TorqueDistanceMultiplier, 0f), ForceMode.Impulse);
            //rb.AddRelativeForce( new Vector3(distanceMultiplier * deltaOarPosition.x * paddleMultiplier.x , 0, distanceMultiplier * deltaOarPosition.z * paddleMultiplier.z), ForceMode.Impulse);

		}
	}

	void FixedUpdate(){
		nowOarPosition = oar.transform.position;
		nowOarRelativePosition = transform.position - oar.transform.position;
	}

	void LateUpdate(){
		lastOarPosition = nowOarPosition;
		lastOarRelativePosition = nowOarRelativePosition; 
	}
}
	