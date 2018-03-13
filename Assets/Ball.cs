using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float launchSpeed;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
	
	void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Launch();
    }

    public void Launch() {
        rigidBody.velocity = new Vector3(0, 0, launchSpeed);
        audioSource.Play();
    }

    void Update() {
		
	}

}
