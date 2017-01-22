using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioRandomly : MonoBehaviour {
	AudioSource audioSource;
	private float randomTime = 10.0f;
	private float timeCounter = 0.0f;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCounter > randomTime) {
			randomTime = Random.Range (8.0f, 12.0f);
			timeCounter = 0.0f;
			audioSource.Stop ();
			audioSource.Play ();
		} 

		timeCounter += Time.deltaTime;
	}
}
