using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	Slider mainSlider;

	// Use this for initialization
	void Start () {
		mainSlider = GetComponent<Slider> ();
		mainSlider.onValueChanged.AddListener (delegate {
			ValueChangeCheck ();
		}
		);
	}

	public void ValueChangeCheck() {
		if (mainSlider.value <= 0) {
			print ("You lose");
		} else if (mainSlider.value >= 1) {
			print ("You win");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
