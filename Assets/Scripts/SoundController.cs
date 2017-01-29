using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	private GameObject musicController;
	public float defaultMusicVolume;
	public float defaultSFXVolume;
	public AudioClip cheer;
	public AudioClip splash;
	public AudioClip seagulls;
	public AudioClip waves;
	public AudioClip music;

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
		PlayMusic (music);
	}
	
	// Update is called once per frame
	void Update () {
		PlayWavesRandomly ();
	}

	public void PlayOneShot(AudioClip audio){
		audioSource.PlayOneShot (audio);
	}

	public void PlayOneShot(AudioClip[] audios){
		audioSource.PlayOneShot(audios[Random.Range(0,audios.Length)]);
	}


	public void PlayMusic(AudioClip audio){
		AudioSource musicAudioSource = transform.GetComponentInChildren<AudioSource> ();
		musicAudioSource.clip = audio;
		musicAudioSource.volume = defaultMusicVolume;
		musicAudioSource.loop = true;
		musicAudioSource.Play ();
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
 