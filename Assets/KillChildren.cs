using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillChildren : MonoBehaviour {

	private GameObject sliderObject;
	private Slider slider;

	void Start(){
		sliderObject = GameObject.FindGameObjectWithTag ("Slider");
		slider = sliderObject.GetComponent<Slider> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "DeadZone") {
			Destroy (this.gameObject);
			slider.value -= 0.02f;
		} else if (other.tag == "SafeZone") {
			Destroy (this.gameObject);
			slider.value += 0.02f;
		}
	}
}
