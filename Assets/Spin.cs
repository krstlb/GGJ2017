using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	Rigidbody2D rb;
	float rotationSpeed = 0.01f;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddTorque(rotationSpeed, ForceMode2D.Force);
	}
}
