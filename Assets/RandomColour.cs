using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	float rValue,gValue,bValue;

	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		rValue = Random.Range(0f, 0.3f);
		gValue = Random.Range(0.3f, 0.5f);
		bValue = Random.Range(0.4f, 0.9f);
		changeColor(rValue, gValue, bValue);
	}

	void changeColor(float r, float g, float b) {
		
		Color tempColor;
		tempColor = new Color (rValue, gValue, bValue);
		spriteRenderer.color = tempColor;
	}
}
