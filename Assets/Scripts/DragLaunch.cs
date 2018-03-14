﻿using System.Collections;
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
        // Capture time & position of drag start
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd() {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(launchVelocity);
    }

}
