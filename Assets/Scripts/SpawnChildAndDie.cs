﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChildAndDie : MonoBehaviour {
	public GameObject child;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnAndDie ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnAndDie() {
		yield return new WaitForSeconds(2f);
		Instantiate (child, this.gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}