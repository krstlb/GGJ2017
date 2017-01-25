using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillChildren : MonoBehaviour {

	private GameObject sliderObject;
	public GameObject particleEffect;
	private GameObject cheerGameObject;
	private Slider slider;
	public float maxLifetime;
	AudioSource audioSource;
	AudioSource cheerAudioSource;
	AudioClip[] audioClips;
	AudioClip audioClipCheer;
	private const float SLIDER_VALUE = 0.05f;

	void Start(){
		audioSource = GetComponent<AudioSource> ();
		audioClips = new AudioClip[] {
			(AudioClip)Resources.Load ("Sound/dying1"),
			(AudioClip)Resources.Load ("Sound/dying2"),
			(AudioClip)Resources.Load ("Sound/dying3"),
			(AudioClip)Resources.Load ("Sound/dying4"),
			(AudioClip)Resources.Load ("Sound/dying5"),
			(AudioClip)Resources.Load ("Sound/dying6"),
			(AudioClip)Resources.Load ("Sound/dying7")
		};
		audioClipCheer = (AudioClip)Resources.Load ("Sound/cheer");

		sliderObject = GameObject.FindGameObjectWithTag ("Slider");
		if(sliderObject!=null){
			slider = sliderObject.GetComponent<Slider> ();
		}

		StartCoroutine(DestroyChildAndInstantiateParticleEffect(11.5f));
	}

	IEnumerator DestroyChildAndInstantiateParticleEffect(float secondsWait) {
		Destroy (gameObject, maxLifetime);
		yield return new WaitForSeconds (secondsWait);
		Instantiate (particleEffect, gameObject.transform.position, Quaternion.identity);

		audioSource.clip = audioClips [Random.Range (0, audioClips.Length)];
		audioSource.Stop ();
		audioSource.Play ();

		if (slider!=null) {
			slider.value -= SLIDER_VALUE;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		// dying
		if ((other.tag == "DeadZone" && this.tag == "Child") || 
			(other.tag == "SafeZone" && this.tag == "Turtle")) {

			StartCoroutine (DestroyChildAndInstantiateParticleEffect (0.01f));
		// cheering
		} else if ((other.tag == "SafeZone" && this.tag == "Child") || 
			(other.tag == "DeadZone" && this.tag == "Turtle")) {

			cheerGameObject = new GameObject ("CheerGameObject");
			cheerGameObject.AddComponent<AudioSource> ();
			cheerAudioSource = cheerGameObject.GetComponent<AudioSource>();
			cheerAudioSource.clip = audioClipCheer;
			cheerAudioSource.Stop ();
			cheerAudioSource.Play ();

			Destroy (this.gameObject);
			if (slider != null) {
				slider.value += SLIDER_VALUE;
			}
		}
	}
}
