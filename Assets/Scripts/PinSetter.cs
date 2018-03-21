using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    public GameObject pinSet;
    
    private Ball ball;
    private Animator animator;
    private PinCounter pinCounter;
    private ActionMaster actionMaster = new ActionMaster(); // Needed here since only one instance

	void Start() {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	void Update() {
		
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

    public void PerformAction(ActionMaster.Action action) {
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            pinCounter.ResetCount();
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            pinCounter.ResetCount();
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle EndGame yet");
        }
    }

}
