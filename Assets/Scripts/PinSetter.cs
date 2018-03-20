using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
    public int lastStandingCount = -1;
    public Text standingDisplay;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private bool ballEnteredBox = false;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	void Update() {
		standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            UpdateStandingCountAndSettle();
        }
	}

    public void RaisePins() {
        Debug.Log("Raising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void RenewPins() {
        Debug.Log("Renewing pins");
        Instantiate(pinSet, new Vector3(0, 0, 1829), Quaternion.identity);
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

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log("Pinfall: " + pinFall + " " + action);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle EndGame yet");
        }

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

}
