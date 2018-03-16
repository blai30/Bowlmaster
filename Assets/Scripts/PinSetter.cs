﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 40f;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update() {
		standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            CheckStanding();
        }
	}

    public void RaisePins() {
        // Raise standing pins only by distanceToRaise
        Debug.Log("Raising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                pin.transform.Translate(new Vector3(0, distanceToRaise, 0));
            }
        }

    }

    public void LowerPins() {
        Debug.Log("Lowering pins");
    }

    public void RenewPins() {
        Debug.Log("Renewing pins");
    }

    void CheckStanding() {
        // Update the lastStandingCount
        // Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) { // If last change > 3s ago
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled() {
        ball.Reset();
        lastStandingCount = -1; // Indicates pins have settled and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding() {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standing++;
            }
        }

        return standing;
    }

    void OnTriggerEnter(Collider collider) {
        GameObject thingHit = collider.gameObject;

        // Ball enters play box
        if (thingHit.GetComponent<Ball>()) {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider) {
        GameObject thingLeft = collider.gameObject;

        if (thingLeft.GetComponent<Pin>()) {
            Destroy(thingLeft);
        }
    }

}
