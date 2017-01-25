using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillChildren : MonoBehaviour {

	private GameObject sliderObject;
	public GameObject particleEffect;
	private Slider slider;
	public float maxLifetime;
	AudioSource audioSource;
	AudioClip[] audioClips;

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
			
		sliderObject = GameObject.FindGameObjectWithTag ("Slider");
		if(sliderObject!=null){
			slider = sliderObject.GetComponent<Slider> ();
		}

		StartCoroutine(DestroyChildAndInstantiateParticleEffect());
	}

	IEnumerator DestroyChildAndInstantiateParticleEffect() {
		print ("asfd");
		Destroy (gameObject, maxLifetime);
		yield return new WaitForSeconds (11.5f);
		Instantiate (particleEffect, gameObject.transform.position, Quaternion.identity);

		audioSource.clip = audioClips [Random.Range (0, audioClips.Length)];
		audioSource.Stop ();
		audioSource.Play ();

		if (slider!=null) {
			slider.value -= 0.1f;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "DeadZone") {
			audioSource.clip = audioClips [Random.Range (0, audioClips.Length)];
			audioSource.Stop ();
			audioSource.Play ();

			Destroy (this.gameObject);
			if (slider != null) {
				slider.value -= 0.1f;
			}

		} else if (other.tag == "SafeZone") {
			audioSource.clip = (AudioClip)Resources.Load ("Sound/cheer");
			audioSource.Stop ();
			audioSource.Play ();

			Destroy (this.gameObject);
			if (slider != null) {
				slider.value += 0.1f;
			}
		}
	}
}
