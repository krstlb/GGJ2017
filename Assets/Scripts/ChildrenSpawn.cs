﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenSpawn : MonoBehaviour {
	public GameObject turtlePrefab;
	public GameObject bubbles;
	public GameObject algae;
	public int xMin,xMax,yMin,yMax;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 1f,3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(){
		
		if (Random.value < 0.5f) {
			SpawnBubbles ();
		} else {
			SpawnAlgae ();
		}
	}

	void SpawnBubbles() {
		Instantiate (bubbles, new Vector3 (Random.Range (xMin, xMax), Random.Range (yMin, yMax), 0), Quaternion.identity);
	}

	void SpawnAlgae() {
		Instantiate (algae, new Vector3 (Random.Range (xMin, xMax), Random.Range (yMin, yMax), 0), Quaternion.identity);
	}
}
