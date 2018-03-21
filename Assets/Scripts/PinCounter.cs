﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private GameManager gameManager;

	void Start() {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	void Update() {
		standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
	}

    public void ResetCount() {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.name == "Ball") {
            ballOutOfPlay = true;
        }
    }

    void UpdateStandingCountAndSettle() {
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
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; // Indicates pins have settled and ball not back in box
        ballOutOfPlay = false;
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

}
