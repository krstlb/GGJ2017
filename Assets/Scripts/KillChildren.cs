using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillChildren : MonoBehaviour {

	private SoundController soundController;

	private GameObject sliderObject;
	public GameObject particleEffect;
	private GameObject cheerGameObject;
	private Slider slider;
	public float maxLifetime;
	private const float SLIDER_VALUE = 0.05f;

	void Start(){
		soundController = GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ();
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

		//Play victim dying sound
		soundController.PlayOneShot(soundController.victimDeathSounds);

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
			soundController.PlayOneShot (soundController.cheer);
			Destroy (this.gameObject);
			if (slider != null) {
				slider.value += SLIDER_VALUE;
			}
		}
	}
}
