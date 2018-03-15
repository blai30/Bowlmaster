using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;
	
	void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity) {
        inPlay = true;
        
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource.Play();
    }

    public void Reset() {
        Debug.Log("Resetting ball");
        inPlay = false;
        transform.position = ballStartPos;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }

}
