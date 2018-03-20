using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;
	
	void Start() {
		ball = GetComponent<Ball>();
	}

    public void MoveStart(float amount) {
        if (!ball.inPlay) {
            Debug.Log("Ball moved " + amount);
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }            
    }

    public void DragStart() {
        if (!ball.inPlay) {
            // Capture time & position of drag start
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd() {
        if (!ball.inPlay) {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = Mathf.Clamp((dragEnd.x - dragStart.x) / dragDuration, -50f, 50f);
            float launchSpeedZ = Mathf.Clamp((dragEnd.y - dragStart.y) / dragDuration, 10f, 500f);

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Launch(launchVelocity);
        }
    }

}
