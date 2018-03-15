using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;
	
	void Start() {
		print(name + " Standing: " + IsStanding());
	}
	
	void Update() {
		
	}

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        return tiltInX < standingThreshold && tiltInZ < standingThreshold;
    }

}
