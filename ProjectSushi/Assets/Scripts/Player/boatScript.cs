using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BUtils;

public class boatScript : MonoBehaviour {


    public GameObject boat;
    public GameObject VRhead;

    [Range(-2, 2)]
    public float movement;
    [Range(0,1)]
    public float forwardSpeed;
    [Range(0, 1)]
    public float sideSpeed;
    public bool debug;

    float rotationAngle;

    void boatRotateToDirection(float movementValue) {

        float lerpTime = .5f;
        float currentLerpTime = 0f;

        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
        float perc = currentLerpTime / lerpTime;
        perc = Mathf.Sin(perc * Mathf.PI * 0.5f);

        boat.transform.localRotation = Quaternion.Slerp(boat.transform.localRotation, 
                                  Quaternion.Euler(boat.transform.localRotation.x, boat.transform.localRotation.y, boat.transform.localRotation.z - movementValue * 15), 
                                  perc);

    }

    // Update is called once per frame
    void Update () {
        if (!debug) movement = VRhead.transform.localPosition.x;

        transform.Translate(new Vector3(movement * sideSpeed, 0f, forwardSpeed), Space.World);
        boatRotateToDirection(movement);
    }
}
