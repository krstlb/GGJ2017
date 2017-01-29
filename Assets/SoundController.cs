using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public AudioClip backgroundMusic;
	public AudioClip cheer;
	public AudioClip splash;
	public AudioClip seagulls;
	public AudioClip waves;

	public AudioClip[] victimDeathSounds;

	private AudioSource audioSource;


	//Random Wave Sound
	public float timeUntilNextWave = 10.0f;
	public float minimumWaveInterval = 8f;
	public float maximumWaveInterval = 12f;
	private float timeSinceLastWave = 0.0f;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		PlayBackgroundMusic ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayWavesRandomly ();
	}

	public void PlayBackgroundMusic(){
		audioSource.loop = true;
		audioSource.clip = backgroundMusic;
		audioSource.Play ();
	}

	public void PlayOneShot(AudioClip audio){
		audioSource.PlayOneShot (audio);
	}

	public void PlayOneShot(AudioClip[] audios){
		audioSource.PlayOneShot(audios[Random.Range(0,audios.Length)]);
	}

	void PlayWavesRandomly() {
		if (timeSinceLastWave > timeUntilNextWave) {
			audioSource.PlayOneShot (waves);
			timeSinceLastWave = 0.0f;
			timeUntilNextWave = Random.Range (minimumWaveInterval, maximumWaveInterval);
		} 
		timeSinceLastWave += Time.deltaTime;
	}
}
 