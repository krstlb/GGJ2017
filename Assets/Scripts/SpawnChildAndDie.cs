﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChildAndDie : MonoBehaviour {
	public GameObject child;

	private SoundController soundController;
	// Use this for initialization
	void Start () {

		soundController = GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ();

		StartCoroutine (SpawnAndDie ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnAndDie() {
		yield return new WaitForSeconds(2f);
		Instantiate (child, gameObject.transform.position, Quaternion.identity);
		soundController.PlayOneShot (soundController.splash);
		Destroy(gameObject);
	}
}
