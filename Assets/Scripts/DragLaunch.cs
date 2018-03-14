using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
	
	void Start() {
		ball = GetComponent<Ball>();
	}

    public void DragStart() {

    }

    public void DragEnd() {
        
    }

}
