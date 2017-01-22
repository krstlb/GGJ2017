using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillChildren : MonoBehaviour {

	private GameObject sliderObject;
	public GameObject particleEffect;
	private Slider slider;
	public float maxLifetime;


	void Start(){
		sliderObject = GameObject.FindGameObjectWithTag ("Slider");
		if(sliderObject!=null){
			slider = sliderObject.GetComponent<Slider> ();
		}
		StartCoroutine(DestroyChildAndInstantiateParticleEffect());
	}

	IEnumerator DestroyChildAndInstantiateParticleEffect() {
		Destroy (gameObject, maxLifetime);
		yield return new WaitForSeconds (19.6f);
		Instantiate (particleEffect, gameObject.transform.position, Quaternion.identity);
		slider.value -= 0.1f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "DeadZone") {
			Destroy (this.gameObject);
			if (slider != null) {
				slider.value -= 0.1f;
			}
		} else if (other.tag == "SafeZone") {
			Destroy (this.gameObject);
			if (slider != null) {
				slider.value += 0.1f;
			}
		}
	}
}
