using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that moves the gameObject its attached to at certain given speed
public class FollowMe : MonoBehaviour {

    // The speed to move our object
    public float speed = 2f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
	}
}
