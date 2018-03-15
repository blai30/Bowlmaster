using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;
	
	void Start() {
		IsStanding();
	}
	
	void Update() {
		
	}

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        
        float tiltInX = rotationInEuler.x;
        float tiltInZ = rotationInEuler.z;

        print(tiltInX + ", " + tiltInZ);
        return true;
    }

}
