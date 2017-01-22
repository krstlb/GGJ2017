using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	Slider mainSlider;

	public GameObject winText;
	public GameObject loseText;

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
			lose ();
		} else if (mainSlider.value >= 1) {
			win ();
		}
	}

	void win(){
		Color tempColor = winText.GetComponent<Text> ().color;
		tempColor.a = 1.0f;
		winText.GetComponent<Text> ().color = tempColor;
		mainSlider.gameObject.SetActive(false);
	}

	void lose(){
		Color tempColor = winText.GetComponent<Text> ().color;
		tempColor.a = 1.0f;
		loseText.GetComponent<Text> ().color = tempColor;
		mainSlider.gameObject.SetActive(false);
	}
}
