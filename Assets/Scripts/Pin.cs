using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;
    public float distToRaise = 40f;

    private Rigidbody rigidBody;
	
	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update() {
		
	}

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        
        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        return tiltInX < standingThreshold && tiltInZ < standingThreshold;
    }

    public void RaiseIfStanding() {
        if (IsStanding()) {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
        }
    }

    public void Lower() {
        rigidBody.useGravity = true;
        transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
    }

}
