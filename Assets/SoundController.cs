using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public AudioClip BackgroundMusic;
	public AudioClip Cheer;
	public AudioClip Splash;
	public AudioClip Seagulls;
	public AudioClip Waves;
	public AudioClip Train;
	public AudioClip Cat;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayOneShot(AudioClip audio){
		audioSource.PlayOneShot (audio);
	}
}
 