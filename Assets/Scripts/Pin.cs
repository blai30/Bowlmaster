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
        print(name + " " + transform.rotation.eulerAngles);
        return true;
    }

}
